import { Component, OnInit, inject } from '@angular/core';
import { MatFormFieldControl } from '@angular/material/form-field';
import { Person } from '../models/person.model';
import { Gender } from '../models/gender.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrl: './form.component.scss',
})
export class FormComponent implements OnInit {
  private fb = inject(FormBuilder);
  private http = inject(HttpClient);
  private route = inject(Router);

  public personForm: FormGroup;
  public genders: Gender[];
  public selectedPicture: File;

  public ngOnInit(): void {
    this.http.get(`https://localhost:7126/genders`).subscribe((genders) => {
      this.genders = genders as Gender[];
    });
    this.initForm();
  }

  private initForm(): void {
    this.personForm = this.fb.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      gender: [null, Validators.required],
      picturePath: [''],
      dateBirth: [null, Validators.required],
      firstDayDate: [null, Validators.required],
      contractType: [''],
      contractDueDate: [null],
      department: [''],
      vacationDays: [0, Validators.min(0)],
      freeDays: [0, Validators.min(0)],
      paidFreeDays: [0, Validators.min(0)],
    });
  }

  public onFileSelected(event: any): void {
    const file: File = event.target.files[0];
    this.selectedPicture = file;
    this.personForm.patchValue({
      picturePath: this.selectedPicture.webkitRelativePath,
    });
  }

  public onSubmit() {
    if (!this.personForm.valid) {
      Object.values(this.personForm.controls).forEach((control) => {
        if (control.invalid) {
          control.markAsDirty();
        }
      });
    }
  }

  public onAdd(): void {
    const formData: Person = this.personForm.value;
    this.http
      .post(`https://localhost:7126/person`, formData)
      .subscribe((result) => {
        if (result) {
          this.route.navigateByUrl('http://localhost:4200/');
        }
      });
    if (this.selectedPicture) {
    }
    console.log(formData);
  }
}
