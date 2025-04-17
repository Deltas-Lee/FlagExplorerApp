export interface CountryModel {
  name: {
    official: string;
    common: string;
  };
  flags: {
    svg: string;
    png: string;
  };
  capital: string[]; // Array of strings
  population: number;
}
