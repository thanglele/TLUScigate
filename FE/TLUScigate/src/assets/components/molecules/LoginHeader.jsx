import React from 'react';

const LoginHeader = () => {
  return (
    <div className="flex justify-between items-center mb-4">
      <h3 className="text-2xl font-bold">ĐĂNG NHẬP</h3>
      <img src="src/img/logo-dai-hoc-thuy-loi-inkythuatso.svg" alt="Logo" className="w-10 h-10" /> {/* Thay bằng đường dẫn logo thực tế */}
    </div>
  );
};

export default LoginHeader;