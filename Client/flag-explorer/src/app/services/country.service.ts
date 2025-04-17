import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {  CountryModel } from '../models/country.model';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  private apiUrl = 'https://localhost:7142/';
  constructor(private http: HttpClient) { }

  getCountries(): Observable<CountryModel[]> {
    return this.http.get<CountryModel[]>(`${this.apiUrl}countries`);
  }

  getCountryDetails(name: string): Observable<CountryModel> {
    const encodedName = encodeURIComponent(name.trim());
    const url = `${this.apiUrl}country-details/${encodedName}`;
    console.log('Fetching country details from:', url);
    return this.http.get<CountryModel>(url);
  }
}
