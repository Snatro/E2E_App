import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { PersonDTO } from '../models/personDTO.model';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.scss',
})
export class EmployeeListComponent implements OnInit {
  private http = inject(HttpClient);

  public dataSource: PersonDTO[];
  public displayedColumns: string[] = [
    'id',
    'name',
    'surname',
    'department',
    'picturePath',
  ];

  public ngOnInit(): void {
    this.http.get(`https://localhost:7126/persons`).subscribe((persons) => {
      this.dataSource = persons as PersonDTO[];
    });
  }
}
