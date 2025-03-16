import React from "react";
import Form from "../components/Form";
import HeaderLeftContent from "../components/HeaderLeftContent";
import FormHeader from "../components/FormHeader";
import InputFiled from "../components/InputFiled";
import Button from "../components/Button";

const ForgotPasswordPage = ({ onBackToLogin, onHandleCheckInfo }) => {
  return (
    <>
      <Form>
        <HeaderLeftContent value={"TRƯỜNG ĐẠI HỌC THUỶ LỢI"} />
        <FormHeader
          value="Bạn quên mật khẩu ?"
          className="font-bold text-3xl"
        />
        <InputFiled fontLable={"font-medium"} label="Tài khoản" type="email" placeHolder="Nhập email" />
        <Button
          value="Kiểm tra thông tin"
          textSize="text-sm"
          color={"bg-blue-600"}
          onClick={onHandleCheckInfo}
        />
        <Button
          color={"bg-gray-500"}
          value="Quay lại đăng nhập"
          textSize="text-sm"
          className="bg-gray-500 text-white hover:bg-gray-600"
          onClick={onBackToLogin}
        />
      </Form>
    </>
  );
};

export default ForgotPasswordPage;
