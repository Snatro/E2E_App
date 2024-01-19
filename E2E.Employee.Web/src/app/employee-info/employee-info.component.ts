import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Gender } from '../models/gender.model';
import { Person } from '../models/person.model';
import { switchMap } from 'rxjs';

@Component({
  selector: 'app-employee-info',
  templateUrl: './employee-info.component.html',
  styleUrl: './employee-info.component.scss',
})
export class EmployeeInfoComponent implements OnInit {
  private fb = inject(FormBuilder);
  private http = inject(HttpClient);
  private route = inject(Router);
  private activatedRoute = inject(ActivatedRoute);

  public personForm: FormGroup;
  public person: Person;
  public genders: Gender[];
  public selectedPicture: File;
  private selectedId: number;

  public ngOnInit(): void {
    this.initForm();
    this.http.get(`https://localhost:7126/genders`).subscribe((genders) => {
      this.genders = genders as Gender[];
    });
    this.activatedRoute.params
      .pipe(
        switchMap((params) => {
          this.selectedId = +params['id'];
          return this.http.get<Person>(
            `https://localhost:7126/person/${this.selectedId}`
          );
        })
      )
      .subscribe(
        (person: Person) => {
          this.person = person;
          this.populateForm();
        },
        (error) => {
          console.error('Error fetching person:', error);
        }
      );
  }

  private initForm(): void {
    this.personForm = this.fb.group({
      id: [null],
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

  private populateForm(): void {
    this.personForm = this.fb.group({
      id: this.person.id || null,
      name: this.person.name || '',
      surname: this.person.surname || '',
      gender: this.person.gender || null,
      picturePath: this.person.picturePath || '',
      dateBirth: this.person.dateBirth || null,
      firstDayDate: this.person.firstDayDate || null,
      contractType: this.person.contractType || '',
      contractDueDate: this.person.contractDueDate || null,
      department: this.person.department || '',
      vacationDays: this.person.vacationDays || 0,
      freeDays: this.person.freeDays || 0,
      paidFreeDays: this.person.paidFreeDays || 0,
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

  public onUpdate(): void {
    const formData: Person = this.personForm.value;
    this.http
      .put(`https://localhost:7126/person`, formData)
      .subscribe((result) => {
        if (result) {
          this.route.navigateByUrl('list');
        }
      });
    if (this.selectedPicture) {
    }
    console.log(formData);
  }
}
