import { Component, OnInit } from '@angular/core';
import { PatientService } from '../_services/patient.service';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit {
  patients: any;
  dataSource;

  constructor(private patientService: PatientService) { }

  ngOnInit() {
     this.loadPatients();
  }

  loadPatients() {
    this.patientService.getPatients().subscribe(response => {
        this.patients = response;
    }, error => {
        console.log(error);
    });
  }

}
