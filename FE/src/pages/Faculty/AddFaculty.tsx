import { useState } from "react";
import { useNavigate } from "react-router-dom";
// @ts-ignore
import { createLecture } from "../../api/LectureApi";

const AddFacultyForm = () => {
  const navigate = useNavigate();
  const [facultyData, setFacultyData] = useState({
    maGV: "",
    hoTen: "",
    email: "",
    hocVi: "",
    hocHam:"",
    chucVu: "",
    trangThai: "",
    chuyenNganh: "",
    gioiTinh: "Nam",
    diaChi: "",
    soDienThoai: "",
    ngaySinh: "",
    ghiChu: "",
  });

  const handleAddFaculty = async () => {
    try {
      await createLecture(facultyData);
      navigate("/danh-sach-giang-vien"); // Chuyển hướng sau khi thêm thành công
    } catch (error) {
      console.error("Error adding faculty data:", error);
    }
  };

  const RequiredLabel = ({ children }: { children: string }) => (
    <span className="text-sm font-medium text-gray-700 dark:text-gray-200">
      {children} <span className="text-red-500">*</span>
    </span>
  );

  return (
    <div className="p-6 bg-white rounded-lg shadow-sm dark:bg-gray-800">
      <h1 className="text-2xl font-bold mb-6 text-gray-800 dark:text-white">
        Thêm giảng viên
      </h1>
      <div className="pb-4">
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          <div>
            <RequiredLabel>Họ và tên</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Nhập họ và tên giảng viên"
              value={facultyData.hoTen}
              onChange={(e) =>
                setFacultyData({ ...facultyData, hoTen: e.target.value })
              }
            />
          </div>
          <div>
            <RequiredLabel>Mã giảng viên</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="2251172533"
              value={facultyData.maGV}
              onChange={(e) =>
                setFacultyData({ ...facultyData, maGV: e.target.value })
              }
            />
          </div>
          <div>
            <RequiredLabel>Giới tính</RequiredLabel>
            <select
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData.gioiTinh}
              onChange={(e) =>
                setFacultyData({ ...facultyData, gioiTinh: e.target.value })
              }
            >
              <option value="Nam">Nam</option>
              <option value="Nữ">Nữ</option>
            </select>
          </div>
          <div>
            <RequiredLabel>Ngày Sinh</RequiredLabel>
            <input
              type="date"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData.ngaySinh}
              onChange={(e) =>
                setFacultyData({ ...facultyData, ngaySinh: e.target.value })
              }
            />
          </div>
          <div>
            <RequiredLabel>Email</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="abc@tlu.edu.vn"
              value={facultyData.email}
              onChange={(e) =>
                setFacultyData({ ...facultyData, email: e.target.value })
              }
            />
          </div>
          <div>
            <RequiredLabel>Số điện thoại</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="0985584356"
              value={facultyData.soDienThoai}
              onChange={(e) =>
                setFacultyData({ ...facultyData, soDienThoai: e.target.value })
              }
            />
          </div>
          <div>
            <RequiredLabel>Địa chỉ</RequiredLabel>
            <input
              type="text"
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              placeholder="Hà Nội"
              value={facultyData.diaChi}
              onChange={(e) =>
                setFacultyData({ ...facultyData, diaChi: e.target.value })
              }
            />
          </div>
          <div>
            <RequiredLabel>Chuyên Ngành</RequiredLabel>
            <select
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData.chuyenNganh}
              onChange={(e) =>
                setFacultyData({ ...facultyData, chuyenNganh: e.target.value })
              }
            >
              <option value="AI">AI</option>
              <option value="KTPM">KTPM</option>
              <option value="TMDT">TMDT</option>
            </select>
          </div>
          <div>
            <RequiredLabel>Ngành</RequiredLabel>
            <select
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData.chuyenNganh}
              onChange={(e) =>
                setFacultyData({ ...facultyData, chuyenNganh: e.target.value })
              }
            >
              <option value="Trí tuệ nhân tạo">Trí tuệ nhân tạo</option>
              <option value="Kĩ thuật phần mềm">Kĩ thuật phần mềm</option>
            </select>
          </div>
          <div>
            <RequiredLabel>Học hàm</RequiredLabel>
            <select
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData.hocHam}
              onChange={(e) =>
                setFacultyData({ ...facultyData, hocHam: e.target.value })
              }
            >
              <option value="PGS">PGS</option>
              <option value="GS">GS</option>
              <option value="">Không</option>
            </select>
          </div>
          <div>
            <RequiredLabel>Học vị</RequiredLabel>
            <select
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData.hocVi}
              onChange={(e) =>
                setFacultyData({ ...facultyData, hocVi: e.target.value })
              }
            >
              <option value="TS">TS</option>
              <option value="">Không</option>
            </select>
          </div>
          <div>
            <RequiredLabel>Chức vụ</RequiredLabel>
            <select
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData.chucVu}
              onChange={(e) =>
                setFacultyData({ ...facultyData, chucVu: e.target.value })
              }
            >
              <option value="Trưởng Khoa">Trưởng Khoa</option>
              <option value="Giảng viên">Giảng viên</option>
            </select>
          </div>
          <div>
            <RequiredLabel>Khoa</RequiredLabel>
            <select
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData.trangThai}
              onChange={(e) =>
                setFacultyData({ ...facultyData, trangThai: e.target.value })
              }
            >
              <option value="CNTT">CNTT</option>
              <option value="Kinh Tế">Kinh Tế</option>
            </select>
          </div>
          <div>
            <RequiredLabel>Trạng thái</RequiredLabel>
            <select
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData.trangThai}
              onChange={(e) =>
                setFacultyData({ ...facultyData, trangThai: e.target.value })
              }
            >
              <option value="Đang làm việc">Đang làm việc</option>
              <option value="Nghỉ việc">Nghỉ việc</option>
            </select>
          </div>
        </div>
        <div className="grid grid-cols-1 md:grid-cols-1 gap-4 pt-2">
          <div>
            <RequiredLabel>Ghi chú</RequiredLabel>
            <textarea
              className="w-full mt-1 px-3 py-2 border rounded-lg dark:border-gray-600 dark:bg-gray-700"
              value={facultyData.ghiChu}
              onChange={(e) =>
                setFacultyData({ ...facultyData, ghiChu: e.target.value })
              }
            />
          </div>
        </div>
      </div>
      <div className="space-y-6">
        {/* Nút hành động */}
        <div className="flex justify-end gap-3 pt-6">
          <button
            className="px-6 py-2 text-gray-700 bg-gray-100 rounded-lg hover:bg-gray-200 dark:bg-gray-600 dark:text-gray-200"
            onClick={() => navigate("/danh-sach-giang-vien")}
          >
            Hủy
          </button>
          <button
            className="px-6 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 dark:bg-blue-700 dark:hover:bg-blue-800"
            onClick={handleAddFaculty} // Gọi hàm thêm khi nhấn nút
          >
            Thêm
          </button>
        </div>
      </div>
    </div>
  );
};

export default AddFacultyForm;
