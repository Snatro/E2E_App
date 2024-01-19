import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MAT_DATE_FORMATS, MatOptionModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {
  MAT_MOMENT_DATE_FORMATS,
  MomentDateModule,
} from '@angular/material-moment-adapter';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { EmployeeInfoComponent } from './employee-info.component';

@NgModule({
  declarations: [EmployeeInfoComponent],
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatSelectModule,
    MatOptionModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MomentDateModule,
    RouterModule,
    MatButtonModule,
  ],
  providers: [{ provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS }],
  bootstrap: [EmployeeInfoComponent],
})
export class EmployeeInfoModule {}
