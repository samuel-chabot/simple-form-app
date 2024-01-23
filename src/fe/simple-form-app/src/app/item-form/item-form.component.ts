import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { provideNativeDateAdapter } from '@angular/material/core';
import { MatChipsModule } from '@angular/material/chips';
import { MatButtonModule } from '@angular/material/button';
import { ApplicationAreaOption, ApplicationArea, Item } from '../interfaces';

@Component({
  selector: 'app-item-form',
  standalone: true,
  providers: [provideNativeDateAdapter()],
  imports: [
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatCheckboxModule,
    MatDatepickerModule,
    MatChipsModule,
    ReactiveFormsModule,
    MatButtonModule,
  ],
  templateUrl: './item-form.component.html',
  styleUrl: './item-form.component.scss',
})
export class ItemFormComponent implements OnInit {
  @Input() public item!: Item;
  @Output() public save = new EventEmitter<Item>();
  public form!: FormGroup;
  public applicationAreaOptions: ApplicationAreaOption[] = [
    { value: ApplicationArea.Dashboard, text: 'Dashboard' },
    { value: ApplicationArea.Settings, text: 'Settings' },
    { value: ApplicationArea.UserManagement, text: 'User Management' },
    { value: ApplicationArea.Inventory, text: 'Inventory' },
  ];

  public ngOnInit(): void {
    console.log(this.item);

    this.form = new FormGroup({
      title: new FormControl(this.item.title || '', [Validators.required, Validators.maxLength(100)]),
      applicationArea: new FormControl(ApplicationArea[this.item.applicationArea] || '', [Validators.required]),
      description: new FormControl(this.item.description || '', [Validators.required, Validators.maxLength(2000)]),
      dateTime: new FormControl(this.item.dateTime || '', [Validators.required]),
      videoUrl: new FormControl(this.item.videoUrl || ''),
      resolved: new FormControl(this.item.resolved || false),
      contactEmail: new FormControl(this.item.contactEmail || ''),
      tags: new FormControl(this.item.tags || ['bug']),
    });
  }

  public handleSave(): void {
    if (!this.form.valid) {
      this.form.markAllAsTouched();
      return;
    }

    const formValues = this.form.getRawValue();
    const item: Item = {
      id: this.item?.id,
      title: formValues.title,
      applicationArea: formValues.applicationArea,
      description: formValues.description,
      dateTime: new Date(formValues.dateTime).toISOString(),
      tags: formValues.tags,
      resolved: formValues.resolved,
      videoUrl: formValues.videoUrl,
      contactEmail: formValues.contactEmail,
    };

    this.save.emit(item);
  }
}
