import { useNavigate } from "react-router";

const FacuktyEdit = () => {
  const navigate = useNavigate();

  const RequiredLabel = ({ children }: { children: string }) => (
    <span className="text-sm font-medium text-gray-700 dark:text-gray-200">
      {children} <span className="text-red-500">*</span>
    </span>
  ); 
  
  const handleCancel = () => {
    navigate("/danh-sach-giang-vien");
  };

  return (
    <div className="p-6 bg-white rounded-lg shadow-sm dark:bg-gray-800">
      <h1 className="text-2xl font-bold mb-6 text-gray-800 dark:text-white">
        Chỉnh sửa thông tin giảng viên
      </h1>
      <div className="pb-4">
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          <div>
            <RequiredLabel>Họ và tên</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhập họ và tên giảng viên"
            />
          </div>
          <div>
            <RequiredLabel>Mã giảng viên</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="2251172533"
            />
          </div>
          <div>
            <RequiredLabel>Giới tính</RequiredLabel>
            <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
              <option>Nam</option>
              <option>Nữ</option>
            </select>
          </div>
          <div>
            <RequiredLabel>Ngày Sinh</RequiredLabel>
            <input
              type="date"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhập mã giảng viên"
            />
          </div>
          <div>
            <RequiredLabel>Email</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="abc@tlu.edu.vn"
            />
          </div>
          <div>
            <RequiredLabel>Số điện thoại</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="0985584356"
            />
          </div>
          <div>
            <RequiredLabel>Địa chỉ</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Hà Nội"
            />
          </div>
          <div>
            <RequiredLabel>Chuyên Ngành</RequiredLabel>
            <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
              <option>AI</option>
              <option>KTPM</option>
              <option>TMDT</option>
            </select>
          </div>
          <div>
            <RequiredLabel>Ngành</RequiredLabel>
            <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
              <option>Trí tuệ nhân tạo</option>
              <option>Kĩ thuật phần mềm</option>
            </select>
          </div>
          <div>
            <RequiredLabel>Học hàm</RequiredLabel>
            <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
              <option>PGS</option>
            </select>
          </div>
          <div>
            <RequiredLabel>Học vị</RequiredLabel>
            <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
              <option>TS</option>
            </select>
          </div>
          <div>
            <RequiredLabel>Chức vụ</RequiredLabel>
            <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
              <option>Trưởng Khoa</option>
              <option>Giảng viên</option>
            </select>
          </div>
          <div>
            <RequiredLabel>Khoa</RequiredLabel>
            <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
              <option>CNTT</option>
              <option>Kinh Tế</option>
            </select>
          </div>
          <div>
            <RequiredLabel>Học vị</RequiredLabel>
            <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
              <option>Chọn học vị</option>
              <option>Thạc sĩ</option>
              <option>Tiến sĩ</option>
            </select>
          </div>

          <div>
            <label className="text-sm font-medium text-gray-700 dark:text-gray-200">
              Trạng thái
            </label>
            <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
              <option>Chọn trạng thái</option>
              <option>Đang làm việc</option>
              <option>Nghỉ việc</option>
            </select>
          </div>
        </div>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4 pt-2">
          <div>
            <RequiredLabel>Học vị</RequiredLabel>
            <select className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700">
              <option>Chọn học vị</option>
              <option>Thạc sĩ</option>
              <option>Tiến sĩ</option>
            </select>
          </div>
          <div>
            <RequiredLabel>Ngày vào</RequiredLabel>
            <input
              type="date"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhập mã giảng viên"
            />
          </div>
          <div>
            <RequiredLabel>Nhập mật khẩu</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhâp mật khẩu"
            />
          </div>
        </div>
        <div className="grid grid-cols-1 md:grid-cols-1 gap-4 pt-2">
          <div>
            <RequiredLabel>Ghi chú</RequiredLabel>
            <textarea
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Ghi chú thêm..."
            />
          </div>
        </div>
      </div>
      <div className="space-y-6">
        {/* Nút hành động */}
        <div className="flex justify-end gap-3 pt-6">
          <button
            className="px-6 py-2 text-gray-700 bg-gray-100 rounded-lg hover:bg-gray-200 dark:bg-gray-600 dark:text-gray-200"
            onClick={handleCancel}
          >
            Hủy
          </button>
          <button className="px-6 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 dark:bg-blue-700 dark:hover:bg-blue-800">
            Cập nhật
          </button>
        </div>
      </div>
    </div>
  );
};

export default FacuktyEdit;
