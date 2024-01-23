import { Component, OnDestroy, OnInit } from '@angular/core';
import { ItemFormComponent } from '../item-form/item-form.component';
import { ApiService } from '../api-servce/api-service';
import { Observable, map, skip, take, takeWhile, tap } from 'rxjs';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { Item } from '../interfaces';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-item',
  standalone: true,
  imports: [ItemFormComponent, CommonModule, RouterModule],
  templateUrl: './item.component.html',
  styleUrl: './item.component.scss',
})
export class ItemComponent implements OnInit {
  public alive = true;
  public id$!: Observable<string>;
  public item$!: Observable<Item>;

  constructor(
    private apiService: ApiService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
  ) {}
  public ngOnInit(): void {
    this.id$ = this.activatedRoute.params.pipe(map(params => params['id'] || ''));
    this.id$.pipe(take(1)).subscribe({ next: id => (this.item$ = this.apiService.getItem(id)) });
  }

  public handleSave(item: Item): void {
    console.log(item);

    if (item.id) {
      this.apiService
        .editItem(item)
        .pipe(take(1))
        .subscribe({ next: _ => this.router.navigate(['/']) });
      return;
    }

    this.apiService
      .createItem(item)
      .pipe(take(1))
      .subscribe({ next: _ => this.router.navigate(['/']) });
  }
}
