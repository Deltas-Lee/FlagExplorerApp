import { CountryModel } from './../models/country.model';
import { ChangeDetectorRef, Component } from '@angular/core';
import { CountryService } from '../services/country.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-country-detail',
  templateUrl: './country-detail.component.html',
  styleUrls: ['./country-detail.component.scss']
})
export class CountryDetailComponent {

  countryDetail: CountryModel | null = null;
  errorMessage: string = "";
  countries: CountryModel[] = [];

  constructor (private countryService: CountryService,
    private route: Router,
    private cdr: ChangeDetectorRef,
    private activateRoute: ActivatedRoute,
  ) {
  }

  ngOnInit(): void {
    let countryName = this.activateRoute.snapshot.paramMap.get('name');
    console.log('Country name from route:', countryName);
    if (countryName) {
      countryName = decodeURIComponent(countryName);
      this.countryService.getCountryDetails(countryName).subscribe({
        next: (data) => {
          console.log('API Response:', data);
          this.countryDetail = data;
        },
        error: (error) => {
          console.error('Error fetching country details:', error);
          this.errorMessage = 'Country details could not be loaded.';
        }
      });
    } else {
      console.error('Country name is null');
    }
  }

  fetchCountries(countryName: string): void {
    this.route.navigate(['countries']);
    this.cdr.detectChanges(); // Force Angular to detect changes
  }

}
