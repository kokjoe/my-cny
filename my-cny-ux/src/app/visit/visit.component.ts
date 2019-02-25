import { Component, OnInit } from '@angular/core';
import { PatientService } from '../_services/patient.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { debounceTime, map, startWith } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material';
import { Patient } from '../_models/patient';

@Component({
  selector: 'app-visit',
  templateUrl: './visit.component.html',
  styleUrls: ['./visit.component.css']
})
export class VisitComponent implements OnInit {
  visitType: string[] = ['OutPatient', 'Inpatient', 'Emergency'];
  selectedType: string;
  patients: any;
  visits: any;
  isEditMode: boolean;
  patientNameList: any[] = [];
  a = 'abc';

  filteredOptions: Observable<any[]>;

  visitForm = this.fb.group({
    // PatientId : null,
    PatientId: [null, [Validators.required]],
    VisitDate: null,
    VisitNo: '',
    VisitType: [['OutPatient', 'Inpatient', 'Emergency'], Validators.required]
  });

  constructor(private patientService: PatientService, private fb: FormBuilder, private alert: MatSnackBar) { }

  ngOnInit() {
    this.loadPatients();
    this.loadVisits();
    this.filteredOptions = this.visitForm.get('PatientId').valueChanges.pipe(
      debounceTime(300),
      startWith<string | any>(''),
      map(value => typeof value === 'string' ? value : value.patientName),
      map(name => name ? this.findOption(name) : this.patientNameList.slice())
    );
  }

  findOption(value: string): any[] {
    const filterValue = value.toLowerCase();
    // return this.patientNameList.filter(o => o.patientName.toLowerCase().indexOf(filterValue) === 0);
    return this.patientNameList.filter(o => o.patientName.toLowerCase().includes(filterValue));
  }

  displayFn(id: number) {
    // debugger;
    console.log(this.a);
    if (id === null) {
      return null;
    }
    const index = this.patientNameList.findIndex(a => a.patientId === id);
    return this.patientNameList[index].patientName;
  }

  displayFnWrapper() {
    return (offer) => this.displayFn(offer);
 }

  loadPatients() {
    this.patientService.getPatients()
    .subscribe(response => {
      this.patients = response;
      this.patients.forEach(e => {
        const patientName = e.PatientName;
        const patientId = e.PatientId;
          // console.log('name1', patientName);
          this.patientNameList.push({patientId, patientName});
      });
      console.log('patients', this.patients);
    }, error => {
        console.log(error);
    });
    console.log('name', this.patientNameList);
  }

  loadVisits() {
    this.patientService.getVisits().subscribe(res => {
      this.visits = res;
      console.log('visits', this.visits);
    }, error => {
      console.log(error);
    });
  }

  saveVisit() {
    debugger;
    let newVisit: any;
    newVisit = Object.assign({}, this.visitForm.value);
    delete newVisit.PatientId.PatientName;

    this.patientService.saveVisit(newVisit).subscribe(res => {
      this.popAlert('Visit saved', 'Info');
    }, error => {
      console.log(error);
      this.popAlert('Failed to save visit', 'Info');
    });
  }

  rowClickEvent(e) {
    this.isEditMode = true;
    console.log(e);
    this.visitForm.patchValue({
      PatientId : e.data.Patient.PatientName,
      VisitType : e.data.VisitType,
      VisitNo : e.data.VisitNo,
      VisitDate : e.data.VisitDate
    });
  }

  popAlert(message: string, action: string) {
    this.alert.open(message, action, {duration: 4000});
  }

}
