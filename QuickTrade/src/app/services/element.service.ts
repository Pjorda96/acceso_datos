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

  getMyElements(): firebase.database.Query {
    const user = 'pjorda96'; // obtener del login
    const elements = this.db.database.ref('elements');
    const userkey = this.getUserkey(user);

    return elements.orderByChild('usuario').equalTo(userkey);
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

  getUserkey(user): string {
    const elements = this.db.database.ref('usuarios').orderByChild('nombre').equalTo(user);

    elements.once('value', snapshot => {
      console.log(snapshot.val());
      snapshot.forEach(child => {
        console.log(child.key);
      });
    });

    return 'usuario2';
  }
}
