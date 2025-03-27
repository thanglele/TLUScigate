// src/pages/AuthPages/OTPPage.tsx
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import HeaderLeftContent from "../../components/auth/HeaderLeftContent";
import Form from "../../components/auth/Form";
import FormHeader from "../../components/auth/FormHeader";
import InputField from "../../components/auth/InputField";
import Button from "../../components/auth/Button";
import ChangePasswordPage from "./ChangePasswordPage";
// @ts-ignore
import { checkOTP } from "../../api/authAPI";

const OTPPage: React.FC = () => {
  const navigate = useNavigate();
  const [email, setEmail] = useState<string>("");
  const [otp, setOtp] = useState<string>("");
  const [errorMessage, setErrorMessage] = useState<string>("");
  const [isOTPValid, setOTPValid] = useState<boolean>(false);
  const [isLoading, setIsLoading] = useState<boolean>(false);

  useEffect(() => {
    const storedEmail = localStorage.getItem("resetEmail");
    if (storedEmail) {
      setEmail(storedEmail);
    } else {
      setErrorMessage("Không tìm thấy email. Vui lòng quay lại trang quên mật khẩu!");
    }
  }, []);

  const handleCheckOTP = async () => {
    setErrorMessage("");
    setIsLoading(true);

    if (!otp || otp.length !== 6) {
      setErrorMessage("Mã OTP phải gồm 6 chữ số.");
      setIsLoading(false);
      return;
    }

    if (!email) {
      setErrorMessage("Email không hợp lệ. Vui lòng quay lại trang quên mật khẩu!");
      setIsLoading(false);
      return;
    }

    try {
      await checkOTP({ email, otp });
      setOTPValid(true);
      navigate("/change-password");
    } catch (error: any) {
      setErrorMessage(error.message || "Mã OTP không hợp lệ.");
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="min-h-screen custom-gradient flex justify-center items-center">
      <div className="flex flex-col md:flex-row justify-between w-full max-w-6xl px-5 md:gap-60 m-2">
        {!isOTPValid ? (
          <Form>
            <HeaderLeftContent value="TRƯỜNG ĐẠI HỌC THỦY LỢI" />
            <FormHeader
              datas={
                <>
                  Chúng tôi đã gửi mã của bạn đến: <br /> {email || "Không có email"}
                  <p className="text-xs font-light">
                    Vui lòng kiểm tra mã trong email của bạn, mã này gồm 6 chữ số.
                  </p>
                </>
              }
              className="font-bold text-xl"
            />
            <InputField
              className="font-extrabold"
              label="Nhập mã OTP có 6 chữ số"
              type="text"
              placeHolder="Nhập mã OTP"
              value={otp}
              onChange={(e: React.ChangeEvent<HTMLInputElement>) =>
                setOtp(e.target.value)
              }
            />
            {errorMessage && <p className="text-red-500 text-sm">{errorMessage}</p>}
            <Button
              value={isLoading ? "Đang xử lý..." : "Xác nhận"}
              textSize="text-sm"
              color="bg-blue-600"
              className="bg-blue-600 text-white hover:bg-blue-700"
              onClick={handleCheckOTP}
              //disabled={!email}
            />
          </Form>
        ) : (
          <ChangePasswordPage />
        )}
      </div>
    </div>
  );
};

export default OTPPage;