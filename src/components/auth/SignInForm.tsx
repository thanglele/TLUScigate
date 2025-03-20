// src/pages/AuthPages/SignInForm.tsx
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import Form from "../../components/auth/Form";
import FormHeader from "../../components/auth/FormHeader";
import InputField from "../../components/auth/InputField";
import Button from "../../components/auth/Button";
import Link from "../../components/auth/Link";
import WelcomeContent from "../../components/auth/WelcomeContent";
import ForgotPasswordPage from "../../components/auth/ForgorPasswordPage";
import { login } from "../../api/authAPI";

const SignInForm: React.FC = () => {
  const navigate = useNavigate();
  const [isForgotPassPage, setForgotPassPage] = useState<boolean>(false);
  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [error, setError] = useState<string>("");
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [borderClass, setBorderClass] = useState<string>("border-gray-300");

  const isValidEmail = (email: string): boolean =>
    /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);

  const handleLogin = async () => {
    setIsLoading(true);
    setError("");
    setBorderClass("border-gray-300");

    if (!email) {
      setError("Vui lòng nhập email!");
      setIsLoading(false);
      setBorderClass("border-red-800");
      return;
    }
    if (!isValidEmail(email)) {
      setError("Email không hợp lệ!");
      setIsLoading(false);
      setBorderClass("border-red-800");
      return;
    }
    if (!password) {
      setError("Vui lòng nhập mật khẩu!");
      setIsLoading(false);
      setBorderClass("border-red-800");
      return;
    }
    if (password.length < 8) {
      setError("Mật khẩu phải có ít nhất 8 ký tự!");
      setIsLoading(false);
      setBorderClass("border-red-800");
      return;
    }

    try {
      await login({ email, password });
      setError("");
      setBorderClass("border-green-500");
      navigate("/dashboard");
    } catch (error: any) {
      setError(error.message); // Hiển thị chính xác thông điệp từ API
      setBorderClass("border-red-800");
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
              <FormHeader value="ĐĂNG NHẬP" className="font-bold text-4xl" />
              <InputField
                fontLabel="font-medium"
                label="Tài khoản"
                type="email"
                placeHolder="Nhập email"
                value={email}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) =>
                  setEmail(e.target.value)
                }
                onKeyDown={handleKeyDown}
                borderClass={borderClass}
              />
              <InputField
                fontLabel="font-medium"
                label="Mật khẩu"
                type="password"
                placeHolder="Nhập mật khẩu"
                value={password}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) =>
                  setPassword(e.target.value)
                }
                onKeyDown={handleKeyDown}
                borderClass={borderClass}
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