import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import {
  Table,
  TableBody,
  TableCell,
  TableHeader,
  TableRow,
} from "../../ui/table";
import Badge from "../../ui/badge/Badge";
import { FiEye, FiEdit, FiTrash2 } from "react-icons/fi";
// @ts-ignore
import { fetchLectureData, deleteLecture, viewDetail } from "../../../api/LectureAPI";
import { toast } from "react-toastify";

interface Faculty {
  maGV: string;
  hoTen: string;
  email: string;
  hocVi: string;
  chucVu: string;
  trangThai: string;
  chuyenNganh: string;
  gioiTinh: string;
  diaChi: string;
  soDienThoai: string;
  ngaySinh: string;
  ghiChu: string;
  id: number;
}

interface ErrorModel{
  message: string;
}

export default function BasicTableOne() {
  const navigate = useNavigate();

  const handleViewDetail = async (maGV: number) => {
      console.log("Log: " + maGV);
      navigate('/info-gv'); 
    }
  

  const handleEdit = async (maGV: number) => {
    console.log("Log: " + maGV);
    navigate('/chinh-sua-gv');
  };

  const handleDelete = async (maGV: number) => {
    const confirmDelete = window.confirm("Bạn có muốn xóa giảng viên này không?");
    if (confirmDelete) {
      try {
        toast.info("Đang xóa giảng viên...", {
          position: "top-right",
          autoClose: false,
          toastId: "delete-lecture",
        });

        await deleteLecture(maGV);

        toast.update("delete-lecture", {
          render: "Xóa giảng viên thành công!",
          type: "success",
          autoClose: 3000,
        });

        // Cập nhật lại danh sách sau khi xóa
        const updatedData = await fetchLectureData();
        setFacultyData(updatedData);
      } catch (error) {
        const err = error as ErrorModel;
        console.error("Lỗi khi xóa giảng viên:", err.message);
        toast.update("delete-lecture", {
          render: err.message || "Xóa giảng viên không thành công!",
          type: "error",
          autoClose: 5000,
        });
      }
    } else {
      toast.warn("Hủy xóa giảng viên.", {
        position: "top-right",
        autoClose: 3000,
      });
    }
  };

  const [facultyData, setFacultyData] = useState<Faculty[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const loadFacultyData = async () => {
      try {
        const data = await fetchLectureData();
        setFacultyData(data);
      } catch (error) {
        const err = error as ErrorModel;
        setError(
          err.message || "Không thể tải dữ liệu từ API. Vui lòng thử lại sau!"
        );
        console.error(error);
      } finally {
        setLoading(false);
      }
    };

    loadFacultyData();
  }, []);

  if (loading) return <div className="text-gray-500">Đang tải dữ liệu...</div>;
  if (error) return <div className="text-red-500">{error}</div>;

  return (
    <div className="overflow-hidden rounded-xl border border-gray-200 bg-white dark:border-white/[0.05] dark:bg-white/[0.03]">
      <div className="max-w-full overflow-x-auto">
        <div className="min-w-[1102px]">
          <Table>
            <TableHeader className="border-b border-gray-100 dark:border-white/[0.05]">
              <TableRow>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  <p className="text-lg">#</p>
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  HỌ VÀ TÊN
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  EMAIL
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  TRẠNG THÁI
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  KHOA
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  CHUYÊN NGÀNH
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  NGÀY VÀO
                </TableCell>
                <TableCell
                  isHeader
                  className="px-5 py-3 font-medium text-gray-500 text-start text-theme-xs dark:text-gray-400"
                >
                  HÀNH ĐỘNG
                </TableCell>
              </TableRow>
            </TableHeader>

            <TableBody className="divide-y divide-gray-100 dark:divide-white/[0.05]">
              {facultyData.map((faculty) => (
                <TableRow key={faculty.id}>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    {faculty.maGV}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    {faculty.hoTen}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    {faculty.email}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-start text-theme-sm dark:text-gray-400">
                    <Badge
                      size="sm"
                      color={
                        faculty.trangThai === "Đang làm việc"
                          ? "success"
                          : faculty.trangThai === "Nghỉ hưu"
                          ? "warning"
                          : "error"
                      }
                    >
                      {faculty.trangThai}
                    </Badge>
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {faculty.chucVu}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {faculty.chuyenNganh}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    {faculty.ngaySinh}
                  </TableCell>
                  <TableCell className="px-4 py-3 text-gray-500 text-theme-sm dark:text-gray-400">
                    <div className="flex items-center gap-2">
                      <button
                        className="text-blue-600 hover:text-blue-900 transition-colors"
                        onClick={() => handleViewDetail(faculty.id)}
                      >
                        <FiEye className="w-4 h-4" />
                      </button>
                      <button
                        className="text-green-600 hover:text-green-900 transition-colors"
                        onClick={() => handleEdit(faculty.id)}
                      >
                        <FiEdit className="w-4 h-4" />
                      </button>
                      <button
                        className="text-red-600 hover:text-red-900 transition-colors"
                        onClick={() => handleDelete(faculty.id)}
                      >
                        <FiTrash2 className="w-4 h-4" />
                      </button>
                    </div>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </div>
      </div>
    </div>
  );
}