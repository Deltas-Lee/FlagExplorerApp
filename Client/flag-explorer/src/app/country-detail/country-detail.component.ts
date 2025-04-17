import { CountryModel } from './../models/country.model';
import { Component } from '@angular/core';
import { CountryService } from '../services/country.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-country-detail',
  templateUrl: './country-detail.component.html',
  styleUrls: ['./country-detail.component.scss']
})
export class CountryDetailComponent {

  countryDetail: CountryModel | null = null;
  errorMessage: string = "";

  constructor (private countryService: CountryService,
    private route: ActivatedRoute,
  ) {
  }

  ngOnInit(): void {
    const countryName = this.route.snapshot.paramMap.get('name');
    console.log('Country name from route:', countryName);
    if (countryName) {
      this.countryService.getCountryDetails(countryName).subscribe({
        next: (data) => {
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
  }
