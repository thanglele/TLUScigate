import React, { useState } from "react";
import HeaderLeftContent from "../components/HeaderLeftContent";
import Form from "../components/Form";
import FormHeader from "../components/FormHeader";
import InputFiled from "../components/InputFiled";
import Button from "../components/Button";
import ChangePasswordPage from "./ChangePasswordPage";

const OTPPage = () => {
  const email = "2251172378@e.tlu.edu.vn";
  const [isOTP, setOTP] = useState(false);

  const handleCheckOTP = () => {
    setOTP(true);
  };

  return (
    <div className="min-h-screen custom-gradient flex justify-center items-center">
      <div className="flex flex-col md:flex-row justify-between w-full max-w-6xl px-5 md:gap-60 m-2">
        {!isOTP ? (
          <Form>
            <HeaderLeftContent value="TRƯỜNG ĐẠI HỌC THUỶ LỢI" />
            <FormHeader
              value={
                <>
                  Chúng tôi đã gửi mã của bạn đến: <br /> {email}
                  <p className="text-xs font-light">
                    Vui lòng kiểm tra mã trong email của bạn, mã này gồm 6 chữ số.
                  </p>
                </>
              }
              className="font-bold text-xl"
            />
            <InputFiled
              className="font-extrabold"
              label="Nhập mã OTP có 6 chữ số"
              type="text"
              placeHolder="Nhập mã OTP"
            />
            <Button
              value="Xác nhận"
              textSize="text-sm"
              color={"bg-blue-600"}
              className="bg-blue-600 text-white hover:bg-blue-700"
              onClick={handleCheckOTP}
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
