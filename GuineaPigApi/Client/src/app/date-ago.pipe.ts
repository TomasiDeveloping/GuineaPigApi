import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
  name: 'dateAgo',
  pure: true
})
export class DateAgoPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    if (value) {
      const seconds = Math.floor((+new Date() - +new Date(value)) / 1000);
      if (seconds < 29) // less than 30 seconds ago will show as 'Just now'
        return 'Gerade jetzt';
      const intervals = {
        'Jahr': 31536000,
        'Monat': 2592000,
        'Woche': 604800,
        'Tag': 86400,
        'Stunde': 3600,
        'Minute': 60,
        'Sekunde': 1
      };
      let counter;
      for (const i in intervals) {
        // @ts-ignore
        counter = Math.floor(seconds / intervals[i]);
        if (counter > 0)
          if (counter === 1) {
            return counter + ' ' + i; // singular (1 day ago)
          } else if (i == 'Woche' || i == 'Stunde' || i == 'Minute' || i == 'Sekunde') {
            return counter + ' ' + i + 'n';
          } else {
            return counter + ' ' + i + 'e'; // plural (2 days ago)
          }
      }
    }
    return value;
  }

}
