import {Injectable} from '@angular/core';
import { data } from '../../global/storage';
import {IData, IHogar, IInmobiliaria, IMotor, ITecnologia} from '../interfaces';
import {AngularFireDatabaseModule} from '@angular/fire/database';
/*import * as firebase from 'firebase/src';
import { environment } from '../../environments/environment';*/

@Injectable()
export class ElementService {
  constructor(
    private db: AngularFireDatabaseModule,
  ) { }

  getElements(): (IData | IMotor | IInmobiliaria | ITecnologia | IHogar)[] {
    const elements = this.db.database.ref('elements');
    const elem: (IData | IMotor | IInmobiliaria | ITecnologia | IHogar)[] = [];
    elements.once('value', snapshot => snapshot.forEach(child => elem.push(child.val())));
    return elem;
  }

  // getElement(id: number): (IMotor | IInmobiliaria | ITecnologia | IHogar) {
  //   console.log(data.filter(el => el.id === id));
  //   return data.filter(el => el.id === id)[0];
  // }

  // putElement(element: (IMotor | IInmobiliaria | ITecnologia | IHogar | IData)): void {
  //   data.push(element);
  // }

  setElement(element: IData | IMotor | IInmobiliaria | ITecnologia | IHogar): void {
    const dbRef = this.db.database.ref('elements');
    dbRef.push(element);
  }
}
