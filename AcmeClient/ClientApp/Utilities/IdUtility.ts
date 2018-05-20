import PathUtility from './PathUtility';

export default class IdUtility {

    static getId() {
        return window.localStorage.getItem(PathUtility.AcmeId);
    }

    static setId(id: string) {
        window.localStorage.setItem(PathUtility.AcmeId, id);
    }

    static removeId(): void {
        window.localStorage.removeItem(PathUtility.AcmeId);
    }
}