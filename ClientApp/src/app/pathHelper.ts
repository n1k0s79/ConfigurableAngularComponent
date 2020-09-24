import { UrlSegment } from '@angular/router';

export class PathHelper {
  public static FromSegments(url: UrlSegment[]): string {
    let ret = '';
    url.forEach(segment => ret += '/' + segment);
    return ret.substring(1);
  }

  public static StartsWith(url: UrlSegment[], starts: string[]): boolean {
    const path = PathHelper.FromSegments(url);
    for (let s of starts) {
      if (path.startsWith(s)) {
        return true;
      }
    }    
    return false;
  }
}
