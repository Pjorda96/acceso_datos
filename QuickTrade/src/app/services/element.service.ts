import {Injectable} from '@angular/core';
import {IData, IHogar, IInmobiliaria, IMotor, ITecnologia} from '../interfaces';
import {AngularFireDatabase} from '@angular/fire/database';

@Injectable()
export class ElementService {
  constructor(
    private db: AngularFireDatabase,
  ) { }

  getElements(): firebase.database.Reference {
    return this.db.database.ref('elements');
  }

  getElement(key: string): firebase.database.Reference {
    return this.db.database.ref('/elements/' + key);
  }

  /*putElement(element: (IMotor | IInmobiliaria | ITecnologia | IHogar | IData)): void {
    data.push(element);
  }*/

  setElement(element: IData | IMotor | IInmobiliaria | ITecnologia | IHogar): firebase.database.Reference {
    const dbRef = this.db.database.ref('elements');
    return dbRef.push(element);
  }
}
