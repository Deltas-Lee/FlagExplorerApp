import { Component } from '@angular/core';
import { CountryService } from '../services/country.service';
import { CountryModel } from '../models/country.model';

@Component({
  selector: 'app-countries-list',
  templateUrl: './countries-list.html',
  styleUrls: ['./countries-list.scss'],
})
export class CountriesListComponent {
  countries: CountryModel[] = [];

  constructor(private countryService: CountryService) {}

  ngOnInit(): void {
    this.countryService.getCountries().subscribe({
      next: (data) => {
        this.countries = data;
      },
      error: (error) => {
        console.error('Error fetching countries:', error);
      }
    });
  }
}
