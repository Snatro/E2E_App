import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { PersonDTO } from '../models/personDTO.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.scss',
})
export class EmployeeListComponent implements OnInit {
  private http = inject(HttpClient);
  private route = inject(Router);

  public dataSource: PersonDTO[];
  public displayedColumns: string[] = [
    'id',
    'name',
    'surname',
    'department',
    'picturePath',
    'info',
  ];

  public ngOnInit(): void {
    this.http.get(`https://localhost:7126/persons`).subscribe((persons) => {
      this.dataSource = persons as PersonDTO[];
    });
  }

  public onRowClick(id: number) {
    this.route.navigate(['/info', id]);
  }
}
