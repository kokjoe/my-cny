import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Patient } from '../_models/patient';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class PatientService {
    baseUrl = environment.apiUrl;
    // patients: any;

    constructor(private http: HttpClient) { }

    getPatients(): Observable<any> {
        return this.http.get(this.baseUrl + 'patients');
    }

    getIdentifications() {
        return this.http.get(this.baseUrl + 'identifications');
    }

    getRelationships() {
        return this.http.get(this.baseUrl + 'relationships');
    }

    getVisits() {
        return this.http.get(this.baseUrl + 'visits');
    }

    // savePatient(patient: Patient) {
    //     return this.http.post(this.baseUrl + 'patients', patient);
    // }

    savePatient(patientData: any) {
        return this.http.post(this.baseUrl + 'patients', patientData);
    }

    saveVisit(visitData: any) {
        return this.http.post(this.baseUrl + 'visits', visitData);
    }

    updatePatient(id: number, patientData: any) {
        return this.http.put(this.baseUrl + 'patients/' + id, patientData);
    }


    // saveEContact(econtact: EmergencyContact) {
    //     return this.http.post(this.baseUrl + 'emer', econtact);
    // }

}
