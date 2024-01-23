import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { ApiService } from '../api-service/api-service';
import { Observable, take } from 'rxjs';
import { MatListModule } from '@angular/material/list';
import { CommonModule } from '@angular/common';
import { ApplicationArea, Item } from '../interfaces';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [RouterModule, MatListModule, CommonModule, MatButtonModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
})
export class DashboardComponent {
  public items!: Observable<Item[]>;
  public applicationAreaType = ApplicationArea;
  constructor(private apiService: ApiService) {}

  public ngOnInit(): void {
    this.items = this.apiService.getItems();
  }

  public handleDelete(id: string): void {
    this.apiService
      .deleteItem(id)
      .pipe(take(1))
      .subscribe({ next: _ => (this.items = this.apiService.getItems()) });
  }
}
