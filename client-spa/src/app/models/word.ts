import {Translate} from './translate';



export enum LevelType {
  None = 0,
  First = 1,
  Second = 2,
  Third = 3,
  Compleate = 4
}


export class Word {
  public id: number;
  public created: string;
  public text: string;
  public level: LevelType;
  public phonetic: string;
  public userid: number;
  public translated: Translate[];
}
