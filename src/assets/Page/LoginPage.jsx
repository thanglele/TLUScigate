import React, { useState } from "react";
import WelcomeContent from "../components/WelcomeContent";
import Form from "../components/Form";
import FormHeader from "../components/FormHeader";
import InputFiled from "../components/InputFiled";
import Link from "../components/Link";
import Button from "../components/Button";
import ForgotPasswordPage from "./ForgotPasswordPage";
import { useNavigate } from "react-router-dom";

const LoginPage = () => {
  const navigate = useNavigate();
  const [isForgotPassPage, setForgotPassPage] = useState(false);
  
  const handleLogin = () => {
    navigate("/dashboard");
  };

  const handleForgotPassword = () => {
    setForgotPassPage(true);
  };

  const handleBackToLogin = () => {
    setForgotPassPage(false);
  };

  const handleCheckInfo = () => {
    navigate("/otp");
  }
  return (
    <div className="min-h-screen custom-gradient flex justify-center items-center">
      <div className="flex flex-col md:flex-row justify-between w-full max-w-6xl px-5 md:gap-60 m-2">
        {!isForgotPassPage ? (
          <>
            <WelcomeContent />
            <Form>
              <FormHeader value="ĐĂNG NHẬP" className="font-bold text-4xl" />
              <InputFiled
                fontLable={"font-medium"}
                label="Tài khoản"
                type="email"
                placeHolder="Nhập email"
              />
              <InputFiled
                fontLable={"font-medium"}
                label="Mật khẩu"
                type="password"
                placeHolder="Nhập mật khẩu"
              />
              <Link value="Quên mật khẩu?" onClick={handleForgotPassword} />
              <Button
                value="Đăng nhập"
                textSize="text-sm"
                color={"bg-blue-600"}
                className="bg-blue-600 text-white hover:bg-blue-700"
                onClick={handleLogin}
              />
            </Form>
          </>
        ) : (
          <ForgotPasswordPage onBackToLogin={handleBackToLogin} onHandleCheckInfo={handleCheckInfo} />
        )}
      </div>
    </div>
  );
};

export default LoginPage;
