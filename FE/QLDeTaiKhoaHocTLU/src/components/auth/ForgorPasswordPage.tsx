// src/pages/AuthPages/ForgotPasswordPage.tsx
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import Form from "../../components/auth/Form";
import FormHeader from "../../components/auth/FormHeader";
import InputField from "../../components/auth/InputField";
import Button from "../../components/auth/Button";
import { forgotPassword } from "../../api/authAPI";

interface ForgotPasswordPageProps {
  onBackToLogin: () => void;
}

const ForgotPasswordPage: React.FC<ForgotPasswordPageProps> = ({ onBackToLogin }) => {
  const [email, setEmail] = useState<string>("");
  const [errorMessage, setErrorMessage] = useState<string>("");
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const navigate = useNavigate();

  const isValidEmail = (email: string): boolean => /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);

  const handleCheckInfo = async () => {
    setErrorMessage("");
    setIsLoading(true);

    if (!email) {
      setErrorMessage("Vui lòng nhập email!");
      setIsLoading(false);
      return;
    }

    if (!isValidEmail(email)) {
      setErrorMessage("Email không hợp lệ!");
      setIsLoading(false);
      return;
    }

    try {
      await forgotPassword({ email });
      localStorage.setItem("resetEmail", email);
      alert("Yêu cầu đặt lại mật khẩu đã được gửi! Vui lòng kiểm tra email.");
      navigate("/otp");
    } catch (error: any) {
      const apiErrorMessage = error.message || "Không thể gửi yêu cầu";
      setErrorMessage(apiErrorMessage);
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <Form>
      <FormHeader value="Bạn quên mật khẩu?" className="font-bold text-3xl" />
      <InputField
        fontLabel="font-medium"
        label="Tài khoản"
        type="email"
        placeHolder="Nhập email"
        value={email}
        onChange={(e: React.ChangeEvent<HTMLInputElement>) => setEmail(e.target.value)}
      />
      {errorMessage && <p className="text-red-500 text-sm">{errorMessage}</p>}
      <Button
        value={isLoading ? "Đang xử lý..." : "Kiểm tra thông tin"}
        textSize="text-sm"
        color="bg-blue-600"
        onClick={handleCheckInfo}
      />
      <Button
        color="bg-gray-500"
        value="Quay lại đăng nhập"
        textSize="text-sm"
        className="bg-gray-500 text-white hover:bg-gray-600"
        onClick={onBackToLogin}
      />
    </Form>
  );
};

export default ForgotPasswordPage;