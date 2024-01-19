import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormComponent } from './form/form.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeInfoComponent } from './employee-info/employee-info.component';

const routes: Routes = [
  { path: '', component: EmployeeListComponent },
  { path: 'list', component: EmployeeListComponent },
  { path: 'form', component: FormComponent },
  { path: 'info/:id', component: EmployeeInfoComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
