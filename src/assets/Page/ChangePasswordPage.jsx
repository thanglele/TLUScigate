import React from "react";
import Form from "../components/Form";
import FormHeader from "../components/FormHeader";
import InputFiled from "../components/InputFiled";
import Button from "../components/Button";
import HeaderLeftContent from "../components/HeaderLeftContent";
import { useNavigate } from "react-router-dom";

const ChangePasswordPage = () => {
  const navigate = useNavigate();

  const onBackToLogin = () => {
    alert("Đổi mật khẩu thành công!");
    navigate("/");
  };

  return (
    <>
      <Form>
        <HeaderLeftContent value={"TRƯỜNG ĐẠI HỌC THUỶ LỢI"}/>
        <FormHeader value="Đổi mật khẩu" className="text-4xl font-bold" />
        <InputFiled
          label="Mật khẩu mới"
          type="password"
          placeHolder="Nhập mật khẩu mới"
        />
        <InputFiled
          label="Nhập lại mật khẩu mới"
          type="password"
          placeHolder="Nhập lại mật khẩu mới"
        />
      <Button value="Xác nhận" textSize="text-sm" color={"bg-blue-600"} className="bg-blue-600 text-white hover:bg-blue-700" onClick={onBackToLogin}/> 
      </Form>
    </>
  );
};

export default ChangePasswordPage;
