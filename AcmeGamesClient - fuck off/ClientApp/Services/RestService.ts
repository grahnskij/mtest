import TokenUtility from '../Utilities/TokenUtility';

export default class RestService {
    static AmISignedIn(): boolean {
        //return !!TokenUtility.getToken();
        return true;
    }

    
}