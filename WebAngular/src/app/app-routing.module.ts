import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriesComponent } from './components/categories/categories.component';
import { AddCategoryComponent } from './components/add-category/add-category.component';
import { EditCategoryComponent } from './components/edit-category/edit-category.component';
import { ShippersComponent } from './components/shippers/shippers.component';
import { AddShipperComponent } from './components/add-shipper/add-shipper.component';
import { EditShipperComponent } from './components/edit-shipper/edit-shipper.component';
import { HomePageComponent } from './components/home-page/home-page.component';

const routes: Routes = [
  {
    path: '',
    component: HomePageComponent,
  },
  {
    path: 'categories',
    component: CategoriesComponent,
  },
  {
    path: 'categories/add',
    component: AddCategoryComponent,
  },
  {
    path: 'categories/edit/:id',
    component: EditCategoryComponent,
  },
  {
    path: 'shippers',
    component: ShippersComponent,
  },
  {
    path: 'shippers/add',
    component: AddShipperComponent,
  },
  {
    path: 'shippers/edit/:id',
    component: EditShipperComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
