export interface CountryModel {
  name: {
    common: string;
    official: string;
  };
  capital: string [];
  population: number;
  flags: {
    png: string;
    svg: string;
  };
}
