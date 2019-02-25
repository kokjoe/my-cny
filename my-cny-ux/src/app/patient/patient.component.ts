import { Component, OnInit } from '@angular/core';
import { PatientService } from '../_services/patient.service';
import { Patient } from '../_models/patient';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit {
  patients: any;
  contactObj: any;

  patientData: Patient;

  patientForm: FormGroup;
  contactForm: FormGroup;

  identifications: any;
  relationships: any;

  isEditMode: boolean;
  isContactEditMode: boolean;

  constructor(private patientService: PatientService, private fb: FormBuilder, private fb2: FormBuilder) { }

  ngOnInit() {
    this.loadPatients();
    this.contactObj = [];
    this.loadIdentifications();
    this.loadRelationships();
    this.initialiseForm();
  }

  initialiseForm() {
    this.patientForm = this.fb.group({
      PatientId : null,
      PatientName: ['', [Validators.required, Validators.maxLength(100)]],
      MRN: '',
      Gender: ['', Validators.required],
      DOB: [null, Validators.required],
      ZipCode: 0,
      IdentificationNo: ['', [Validators.required, Validators.maxLength(20)]],
      IdentificationId: 1
    });

    this.contactForm = this.fb2.group({
      EmergencyContactId: null,
      RelationshipId: 1,
      ContactNo: [null, [Validators.required, , Validators.maxLength(20)]],
      IdentificationId: 1,
      IdentificationNo: ['', [Validators.required, Validators.maxLength(20)]]
    });
  }

  phoneNumberValidator(control: AbstractControl): { [key: string]: any } | null {
    const valid = /^\d+$/.test(control.value);
    return valid ? null : { invalidNumber: { valid: false, value: control.value } };
  }

  loadPatients() {
    this.patientService.getPatients().subscribe(response => {
      this.patients = response;
      console.log('patients', this.patients);
    }, error => {
        console.log(error);
    });
  }

  loadIdentifications() {
    this.patientService.getIdentifications().subscribe(res => {
      this.identifications = res;
    }, error => {
      console.log(error);
    });
  }

  loadRelationships() {
    this.patientService.getRelationships().subscribe(res => {
      this.relationships = res;
    }, error => {
      console.log(error);
    });
  }

  savePatient() {
    // tslint:disable-next-line:no-debugger
    // debugger;

    let newPatient: any;
    newPatient = Object.assign({}, this.patientForm.value);

     newPatient.EmergencyContactsResource = this.contactObj;

    // update
    if (this.isEditMode) {
      this.patientService.updatePatient(newPatient.PatientId, newPatient).subscribe(res => {
        console.log('patient updated' + res);
        this.isEditMode = false;
        this.patientForm.reset({IdentificationId: 1});
        this.loadPatients();
      });
    } else {
      delete newPatient.PatientId;
      this.patientService.savePatient(newPatient).subscribe(response => {
        console.log('patient successfully saved: ' + response);
        this.patients.push(newPatient);
        this.patientForm.reset({IdentificationId: 1});
        this.contactObj = [];
      }, error => {
        console.log(error);
      });
      // console.log('trying to save');
    }
  }

  addContact() {
        // tslint:disable-next-line:no-debugger
    //     debugger;
    let newContact: any;
    newContact = Object.assign({}, this.contactForm.value);

    if (this.isContactEditMode) {
      const index = this.contactObj.findIndex(obj =>
        obj.EmergencyContactId === newContact.EmergencyContactId);
      this.contactObj[index] = newContact;
      newContact = {};
    } else {
      this.contactObj.push(newContact);
      console.log('push successful');
      this.contactForm.reset({RelationshipId: 1, IdentificationId: 1});
      newContact = {};
    }
  }

  resetContact() {
    // a = [b, b = a][0];
    this.isEditMode = false;
    this.contactForm.reset({RelationshipId: 1, IdentificationId: 1});
  }

  rowClickEvent(e) {
    this.isEditMode = true;
    console.log(e);
    this.patientForm.patchValue({
      PatientId : e.data.PatientId,
      PatientName: e.data.PatientName,
      MRN: e.data.MRN,
      Gender: e.data.Gender,
      DOB: e.data.DOB,
      ZipCode: e.data.ZipCode,
      IdentificationNo: e.data.IdentificationNo,
      IdentificationId: e.data.IdentificationResource.IdentificationId
    });
    // debugger;
    this.contactObj = [];
    this.contactObj = e.data.EmergencyContactsResource;
  }

  contactGridClick(e) {
    this.isContactEditMode = true;
    console.log(e);
    this.contactForm.patchValue({
      EmergencyContactId: e.data.EmergencyContactId,
      RelationshipId: e.data.RelationshipId,
      ContactNo: e.data.ContactNo,
      IdentificationId: e.data.IdentificationId,
      IdentificationNo: e.data.IdentificationNo
    });
  }



    // savePatient(form: NgForm) {
  //   this.patientService.savePatient(form.value).subscribe(response => {
  //     console.log('patient successfully saved: ' + response);
  //     this.editForm.reset(this.patientData);
  //     }, error => {
  //       console.log(error);
  //     });
  // }
}
