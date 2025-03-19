// src/pages/AuthPages/ChangePasswordPage.tsx
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import Form from "../../components/auth/Form";
import FormHeader from "../../components/auth/FormHeader";
import InputField from "../../components/auth/InputField";
import Button from "../../components/auth/Button";
import HeaderLeftContent from "../../components/auth/HeaderLeftContent";
import { newPassword } from "../../api/authAPI";

const ChangePasswordPage: React.FC = () => {
  const navigate = useNavigate();
  const [password, setPassword] = useState<string>("");
  const [confirmPassword, setConfirmPassword] = useState<string>("");
  const [email, setEmail] = useState<string>("");
  const [error, setError] = useState<string>("");
  const [isLoading, setIsLoading] = useState<boolean>(false);

  useEffect(() => {
    const storedEmail = localStorage.getItem("resetEmail");
    console.log("Stored email:", storedEmail);
    if (storedEmail) {
      setEmail(storedEmail);
    } else {
      setError("Không tìm thấy email. Vui lòng quay lại trang quên mật khẩu!");
    }
  }, []);

  const handleSubmit = async () => {
    setError("");
    setIsLoading(true);

    if (!email) {
      setError("Không tìm thấy email. Vui lòng quay lại trang quên mật khẩu!");
      setIsLoading(false);
      return;
    }

    if (!password) {
      setError("Vui lòng nhập mật khẩu mới");
      setIsLoading(false);
      return;
    }
    if (password.length <= 8) {
      setError("Mật khẩu phải dài hơn 8 ký tự");
      setIsLoading(false);
      return;
    }
    if (!confirmPassword) {
      setError("Vui lòng nhập lại mật khẩu mới");
      setIsLoading(false);
      return;
    }
    if (password !== confirmPassword) {
      setError("Mật khẩu xác nhận không khớp!");
      setIsLoading(false);
      return;
    }

    try {
      console.log("Sending data to API:", { email, password });
      await newPassword({ email, password });
      localStorage.removeItem("resetEmail");
      navigate("/");
    } catch (error: any) {
      const errorMessage =
        error.response?.data?.message || error.message || "Lỗi khi đặt lại mật khẩu";
      setError(errorMessage);
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="min-h-screen custom-gradient flex justify-center items-center">
      <div className="flex flex-col md:flex-row justify-between w-full max-w-6xl px-5 md:gap-60 m-2">
        <Form>
          <HeaderLeftContent value="TRƯỜNG ĐẠI HỌC THỦY LỢI" />
          <FormHeader value="Đổi mật khẩu" className="text-4xl font-bold" />
          <InputField
            label="Mật khẩu mới"
            type="password"
            placeHolder="Nhập mật khẩu mới"
            value={password}
            onChange={(e: React.ChangeEvent<HTMLInputElement>) =>
              setPassword(e.target.value)
            }
          />
          <InputField
            label="Nhập lại mật khẩu mới"
            type="password"
            placeHolder="Nhập lại mật khẩu mới"
            value={confirmPassword}
            onChange={(e: React.ChangeEvent<HTMLInputElement>) =>
              setConfirmPassword(e.target.value)
            }
          />
          {error && <p className="text-red-500 text-sm mb-3">{error}</p>}
          <Button
            value={isLoading ? "Đang xử lý..." : "Xác nhận"}
            textSize="text-sm"
            color="bg-blue-600"
            className="bg-blue-600 text-white hover:bg-blue-700"
            onClick={handleSubmit}
            disabled={!email || isLoading}
          />
        </Form>
      </div>
    </div>
  );
};

export default ChangePasswordPage;