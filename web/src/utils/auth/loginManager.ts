import { message } from "antd";
import axios, { AxiosResponse } from "axios";
import jwtDecode from "jwt-decode";
import { SignInResponse } from "../../pages/signin";

type User = {
  nameid: string;
  unique_name: string;
  email: string;
  nbf: number;
  exp: number;
  iat: number;
};

const userKey = "user";

class LoginManager {
  handleSignUpResponse(res: any) {
    if (res.status === 200) {
      message.success("Zarejestrowano pomyślnie!");

      return true;
    }

    message.error("Coś poszło nie tak. Spróbuj ponownie później.");

    return false;
  }

  handleSignInResponse(res: AxiosResponse<SignInResponse, any>) {
    if (res.status === 200) {
      message.success("Zalogowano pomyślnie!");

      this.userToken = res.data.token;
      axios.defaults.headers.common["Authorization"] = this.authorizationHeader;

      return true;
    }

    message.error("Coś poszło nie tak. Spróbuj ponownie później.");
    return false;
  }

  signOut() {
    localStorage.removeItem(userKey);
    window.location.reload();
  }

  get userToken(): string | null {
    return localStorage.getItem(userKey);
  }

  set userToken(token: string | null) {
    token && localStorage.setItem(userKey, token);
  }

  get isSignedIn(): boolean {
    return !!this.userToken;
  }

  get user(): User | null {
    const token = this.userToken;

    if (token) {
      return jwtDecode(token);
    }

    return null;
  }

  get authorizationHeader(): string {
    return `Bearer ${this.userToken}`;
  }
}

const loginManager = new LoginManager();
export default loginManager;
