import { Component, OnInit, inject } from '@angular/core';
import { Person } from './models/person.model';
import { HttpClient } from '@angular/common/http';
import { PersonDTO } from './models/personDTO.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
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
      this.dataSource = persons as Person[];
    });
  }
}
