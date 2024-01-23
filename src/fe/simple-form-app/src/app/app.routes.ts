import { Routes } from '@angular/router';
import { ItemComponent } from './item/item.component';
import { DashboardComponent } from './dashboard/dashboard.component';

export const routes: Routes = [
  {
    path: '',
    children: [
      { path: '', pathMatch: 'full', component: DashboardComponent },
      { path: 'create', component: ItemComponent },
      {
        path: 'edit/:id',
        component: ItemComponent,
      },
    ],
  },
];
