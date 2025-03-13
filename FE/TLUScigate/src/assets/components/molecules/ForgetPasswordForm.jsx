import React from 'react';
import InputField from '/Users/leduc/QLKHTLU/src/assets/components/atoms/InputFiled.jsx';
import Button from '../atoms/Button';
import Link from '../atoms/Link';

const ForgetPasswordForm = ({ email, setEmail, errorMessage, onSubmit, onBack }) => {
  return (
    <>
      <InputField
        label="Email"
        type="email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        placeholder="Nhập email"
        id="forget-email"
      />
      {errorMessage && (
        <div className="text-xs md:text-sm text-red-500 italic mb-4">{errorMessage}</div>
      )}
      <div className="flex flex-col gap-3">
        <Button onClick={onSubmit} className="bg-blue-600 text-white hover:bg-blue-700">
          Gửi yêu cầu
        </Button>
        <Button onClick={onBack} className="border border-blue-600 text-blue-600 hover:bg-blue-100">
          Quay lại
        </Button>
      </div>
    </>
  );
};

export default ForgetPasswordForm;