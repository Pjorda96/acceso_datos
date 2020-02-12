import {Injectable} from '@angular/core';
import {IData, IHogar, IInmobiliaria, IMotor, ITecnologia} from '../interfaces';
import {AngularFireDatabase} from '@angular/fire/database';

@Injectable()
export class ElementService {
  user = 'usuario2';

  constructor(
    private db: AngularFireDatabase,
  ) { }

  getElements(): (IData | IHogar| IInmobiliaria| IMotor| ITecnologia)[] {
    const data: (IData | IHogar| IInmobiliaria| IMotor| ITecnologia)[] = [];

    this.db.database
        .ref('elements')
        .once('value', snapshot => {
          snapshot.forEach(child => {
            let value = child.val();
            value = {
              ...value,
              id: child.key,
            };
            data.push(value);
          });
        });

    return data;
  }

  getMyElements(user: string = 'pjorda96'): (IData | IHogar| IInmobiliaria| IMotor| ITecnologia)[] {
    // const userkey = this.getUserkey(user);
    const data: (IData | IHogar| IInmobiliaria| IMotor| ITecnologia)[] = [];

    this.db.database
        .ref('elements')
        .orderByChild('usuario')
        .equalTo(this.getUserkey())
        .once('value', snapshot => {
          snapshot.forEach(child => {
            let value = child.val();
            value = {
              ...value,
              id: child.key,
            };
            data.push(value);
          });
        });

    return data;
  }

  getElement(key: string): firebase.database.Reference {
    return this.db.database.ref('/elements/' + key);
  }

  addElement(element: IData | IMotor | IInmobiliaria | ITecnologia | IHogar): void {
    const dbRef = this.db.database.ref('elements');
    dbRef.push(element);
  }

  putElement(element: (IMotor | IInmobiliaria | ITecnologia | IHogar | IData), key: string): void {
    const ref = this.db.database.ref('elements');
    ref.child(key).set(element)
        .catch(err => {
          throw Error(err);
        });
  }

  deleteElement(key: string): void {
    const ref = this.db.database.ref('elements');

    ref.child(key).remove()
        .catch(err => {
          throw Error(err);
        });
  }

  getUserkey(user: string = this.user): string {
    const elements = this.db.database.ref('usuarios').orderByChild('nombre').equalTo(user);

    elements.once('value', snapshot => { // TODO: change
      // console.log(snapshot.val());
      snapshot.forEach(child => {
        // console.log(child.key);
      });
    });

    return this.user; // TODO: do it real
  }
}
