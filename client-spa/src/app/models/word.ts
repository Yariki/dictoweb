import {Translate} from './translate';

export class Word {
  public id: number;
  public created: string;
  public text: string;
  public level: LevelType;
  public phonetic: string;
  public userid: number;
  public translated: Translate[];
}
