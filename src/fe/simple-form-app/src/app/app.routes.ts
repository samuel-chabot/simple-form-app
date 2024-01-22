import { Routes } from '@angular/router';
import { ItemComponent } from './item/item.component';

export const routes: Routes = [
  {
    path: '',
    children: [{ path: 'create', component: ItemComponent }],
  },
];
