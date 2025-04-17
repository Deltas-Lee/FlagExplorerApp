import { ChangeDetectorRef, Component } from '@angular/core';
import { Router } from '@angular/router';
import { CountryService } from '../services/country.service';
import { CountryModel } from '../models/country.model';

@Component({
  selector: 'app-countries-list',
  templateUrl: './countries-list.html',
  styleUrls: ['./countries-list.scss'],
})
export class CountriesListComponent {
  countries: CountryModel[] = [];
  searchQuery: string = '';


  constructor(private countryService: CountryService, private router: Router, private cdr: ChangeDetectorRef) {}

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

  onFlagClick(countryName: string): void {
    this.router.navigate(['/country-details', encodeURIComponent(countryName.trim())]).then(() => {
      this.cdr.detectChanges(); // Force Angular to detect changes
    });
  }
}
