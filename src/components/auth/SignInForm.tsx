import { useState } from "react";
import { useNavigate } from "react-router-dom";
import Form from "../../components/auth/Form";
import FormHeader from "../../components/auth/FormHeader";
import InputField from "../../components/auth/InputField";
import Button from "../../components/auth/Button";
import Link from "../../components/auth/Link";
import WelcomeContent from "../../components/auth/WelcomeContent";
import ForgotPasswordPage from "../../components/auth/ForgorPasswordPage";
// @ts-ignore
import { login } from "../../api/authAPI.js";

const SignInForm: React.FC = () => {
  const navigate = useNavigate();
  const [isForgotPassPage, setForgotPassPage] = useState<boolean>(false);
  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [error, setError] = useState<string>("");
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [emailBorderClass, setEmailBorderClass] = useState<string>("border-gray-300");
  const [passBorderClass, setPassBorderClass] = useState<string>("border-gray-300");

  const isValidEmail = (email: string): boolean =>
    /^[^\s@]+@[^\s@]+\.(com|org|net|edu|gov|mil|biz|info|io|co\.uk|co\.jp)$/.test(email);

  const handleEmailChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const value = e.target.value;
    setEmail(value);
    if (!value) {
      setEmailBorderClass("border-red-800");
    } else if (!isValidEmail(value)) {
      setEmailBorderClass("border-red-800");
    } else {
      setEmailBorderClass("border-green-500");
    }
  };

  const handlePasswordChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const value = e.target.value;
    setPassword(value);
    if (!value || value.length < 8) {
      setPassBorderClass("border-red-800");
    } else {
      setPassBorderClass("border-green-500");
    }
  };

  const handleLogin = async () => {
    setIsLoading(true);
    setError("");

    if (!email) {
      setError("Vui lòng nhập email!");
      setEmailBorderClass("border-red-800");
      setIsLoading(false);
      return;
    }
    if (!isValidEmail(email)) {
      setError("Email không hợp lệ!");
      setEmailBorderClass("border-red-800");
      setIsLoading(false);
      return;
    }
    if (!password) {
      setError("Vui lòng nhập mật khẩu!");
      setPassBorderClass("border-red-800");
      setIsLoading(false);
      return;
    }
    if (password.length < 8) {
      setError("Mật khẩu phải có ít nhất 8 ký tự!");
      setPassBorderClass("border-red-800");
      setIsLoading(false);
      return;
    }

    try {
      await login({ email, password });
      setError("");
      setEmailBorderClass("border-green-500");
      setPassBorderClass("border-green-500");
      navigate("/dashboard");
    } catch (error: any) {
      setError(error.message);
      setEmailBorderClass("border-red-800");
      setPassBorderClass("border-red-800");
    } finally {
      setIsLoading(false);
    }
  };

  const handleKeyDown = (event: React.KeyboardEvent<HTMLInputElement>) => {
    if (event.key === "Enter") {
      handleLogin();
    }
  };

  const handleForgotPassword = () => {
    setForgotPassPage(true);
  };

  return (
    <div className="min-h-screen custom-gradient flex justify-center items-center">
      <div className="flex flex-col md:flex-row justify-between w-full max-w-6xl px-5 md:gap-60 m-2">
        {!isForgotPassPage ? (
          <>
            <WelcomeContent />
            <Form>
              <FormHeader values="ĐĂNG NHẬP" className="font-bold text-4xl" />
              <InputField
                fontLabel="font-medium"
                label="Tài khoản"
                type="email"
                placeHolder="Nhập email"
                value={email}
                onChange={handleEmailChange}
                onKeyDown={handleKeyDown}
                borderClass={emailBorderClass}
              />
              <InputField
                fontLabel="font-medium"
                label="Mật khẩu"
                type="password"
                placeHolder="Nhập mật khẩu"
                value={password}
                onChange={handlePasswordChange}
                onKeyDown={handleKeyDown}
                borderClass={passBorderClass}
              />
              <div className="flex justify-between w-full mt-2">
                {error && <p className="text-red-500 text-sm">{error}</p>}
                <Link value="Quên mật khẩu?" onClick={handleForgotPassword} />
              </div>
              <Button
                value={isLoading ? "Đang xử lý..." : "Đăng nhập"}
                textSize="text-sm"
                color="bg-blue-600"
                className="bg-blue-600 text-white hover:bg-blue-700"
                onClick={handleLogin}
              />
            </Form>
          </>
        ) : (
          <ForgotPasswordPage onBackToLogin={() => setForgotPassPage(false)} />
        )}
      </div>
    </div>
  );
};

export default SignInForm;