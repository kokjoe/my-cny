export interface Patient {
    id: number;
    name: string;
    mrn: string;
    gender: string;
    dob: Date;
    zipcode?: number;
    idNo: string;
    idType: string;
}
