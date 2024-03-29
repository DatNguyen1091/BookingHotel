﻿using BusinessLogic.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Entities
{
    public class Bookings : AuditableBaseEntity<int>
    {
        [StringLength(255)]
        public string BookingCode { get; set; } = default!; // Mã đơn đặt phòng

        public DateTime? TransactionDate { get; set; } // Ngày thực hiện đặt phòng

        public DateTime? CheckInDate { get; set; } // Ngày nhận phòng

        public DateTime? CheckOutDate { get; set; } // Ngày trả phòng

        public short? Status { get; set; } // Trạng thái đơn đặt phòng

        public short? Adult { get; set; } // Số lượng người lớn

        public short? Kid { get; set; } // Số lượng trẻ em

        [Required]
        public decimal TotalAmount { get; set; } // Tổng tiền đơn đặt phòng

        public decimal? DownPayment { get; set; } // Tiền đặt cọc phòng

        [StringLength(255)]
        public string? Payment { get; set; } // Hình thức thanh toán

        [StringLength(255)]
        public string? Message { get; set; } // Lời nhắn

        [Required]
        [StringLength(255)]
        public string UserId { get; set; } = default!; // Id tài khoản đặt phòng
    }
}
