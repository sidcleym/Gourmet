import { Pipe, PipeTransform } from '@angular/core';

import { Restaurante } from '../restaurantes/restaurante.model';

@Pipe({
    name: 'restaurantefilter',
    pure: false
})
export class RestauranteFilterPipe implements PipeTransform {
  transform(items: Restaurante[], filter: Restaurante): Restaurante[] {
    if (!items || !filter) {
      return items;
    }
    // filter items array, items which match and return true will be kept, false will be filtered out
    return items.filter((item: Restaurante) => this.applyFilter(item, filter));
  }
  
  /**
   * Perform the filtering.
   * 
   * @param {Restaurante} book The book to compare to the filter.
   * @param {Restaurante} filter The filter to apply.
   * @return {boolean} True if book satisfies filters, false if not.
   */
  applyFilter(book: Restaurante, filter: Restaurante): boolean {
    for (let field in filter) {
      if (filter[field]) {
        if (typeof filter[field] === 'string') {
          if (book[field].toLowerCase().indexOf(filter[field].toLowerCase()) === -1) {
            return false;
          }
        } else if (typeof filter[field] === 'number') {
          if (book[field] !== filter[field]) {
            return false;
          }
        }
      }
    }
    return true;
  }
}