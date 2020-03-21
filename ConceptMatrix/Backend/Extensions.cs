using SaintCoinach.Xiv.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace ConceptMatrix.Backend
{
    static class Extensions
    {
        public static bool HasSubModel(this ExdData.Item eq)
        {
            return eq.ModelSub.Value1 != 0 ||
                   eq.ModelSub.Value2 != 0 ||
                   eq.ModelSub.Value3 != 0 ||
                   eq.ModelSub.Value4 != 0;
        }

        public static bool IsMainhand(this ExdData.Item eq)
        {
            return eq.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Mainhand);
        }

        public static bool IsOffHand(this ExdData.Item eq)
        {
            return eq.EquipSlotCategory.PossibleSlots.All(s => s.Key == (int)ExdData.Slot.Offhand);
        }

        public static bool IsTwoHanded(this Equipment eq)
        {

            // eq.EquipSlotCategory 
            return false;
        }
        public static string ByteArrayToStringU(byte[] ba)
        {
            if (ba != null)
            {
                StringBuilder hex = new StringBuilder(ba.Length * 2);
                foreach (byte b in ba)
                    hex.AppendFormat("{0:x2} ", b);
                var str = hex.ToString().ToUpper();
                return str.Remove(str.Length - 1);
            }
            else return "0";
        }
        public static byte[] StringToByteArray(String hex)
        {
            string str = hex.Replace(" ", String.Empty);
            int NumberChars = str.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(str.Substring(i, 2), 16);
            return bytes;
        }
        private static double Deg2Rad = (Math.PI * 2) / 360;
        private static double Rad2Deg = 360 / (Math.PI * 2);

        /// <summary>
        /// Convert into a Quaternion assuming the Vector3D represents euler angles.
        /// </summary>
        /// <param name="self"></param>
        /// <returns>Quaternion from Euler angles.</returns>
        public static Quaternion ToQuaternion(this Vector3D self)
        {
            var yaw = self.Y * Deg2Rad;
            var pitch = self.X * Deg2Rad;
            var roll = self.Z * Deg2Rad;

            var c1 = Math.Cos(yaw / 2);
            var s1 = Math.Sin(yaw / 2);
            var c2 = Math.Cos(pitch / 2);
            var s2 = Math.Sin(pitch / 2);
            var c3 = Math.Cos(roll / 2);
            var s3 = Math.Sin(roll / 2);

            var c1c2 = c1 * c2;
            var s1s2 = s1 * s2;

            var x = c1c2 * s3 + s1s2 * c3;
            var y = s1 * c2 * c3 + c1 * s2 * s3;
            var z = c1 * s2 * c3 - s1 * c2 * s3;
            var w = c1c2 * c3 - s1s2 * s3;
            // var norm = Math.Sqrt(x * x + y * y + z * z + w * w);

            return new Quaternion(x, y, z, w);
        }

        public static Vector3D FromQ2(Quaternion q1)
        {
            float sqw = (float)q1.W * (float)q1.W;
            float sqx = (float)q1.X * (float)q1.X;
            float sqy = (float)q1.Y * (float)q1.Y;
            float sqz = (float)q1.Z * (float)q1.Z;
            float unit = sqx + sqy + sqz + sqw; // if normalised is one, otherwise is correction factor
            float test = (float)q1.X * (float)q1.W - (float)q1.Y * (float)q1.Z;
            Vector3D v = new Vector3D();

            if (test > 0.4995f * unit)
            { // singularity at north pole
                v.Y = 2f * Math.Atan2(q1.Y, q1.X);
                v.X = Math.PI / 2;
                v.Z = 0;
                return NormalizeAngles(v * Rad2Deg);
            }
            if (test < -0.4995f * unit)
            { // singularity at south pole
                v.Y = -2f * Math.Atan2(q1.Y, q1.X);
                v.X = -Math.PI / 2;
                v.Z = 0;
                return NormalizeAngles(v * Rad2Deg);
            }
            Quaternion q = new Quaternion(q1.W, q1.Z, q1.X, q1.Y);
            v.Y = (float)Math.Atan2(2f * q.X * q.W + 2f * q.Y * q.Z, 1 - 2f * (q.Z * q.Z + q.W * q.W));     // Yaw
            v.X = (float)Math.Asin(2f * (q.X * q.Z - q.W * q.Y));                             // Pitch
            v.Z = (float)Math.Atan2(2f * q.X * q.Y + 2f * q.Z * q.W, 1 - 2f * (q.Y * q.Y + q.Z * q.Z));      // Roll
            return NormalizeAngles(v * Rad2Deg);
        }

        public static Vector3D NormalizeAngles(Vector3D angles)
        {
            angles.X = NormalizeAngle((float)angles.X);
            angles.Y = NormalizeAngle((float)angles.Y);
            angles.Z = NormalizeAngle((float)angles.Z);
            return angles;
        }

        public static float NormalizeAngle(float angle)
        {
            while (angle > 360)
                angle -= 360;
            while (angle < 0)
                angle += 360;
            return angle;
        }

        public static Quaternion QInv(Quaternion q1)
        {
            return new Quaternion(q1.X, -q1.Y, -q1.Z, -q1.W);
        }
        public static Quaternion QuatMult(Quaternion q1, Quaternion q2)
        {
            double x = q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z - q1.W * q2.W;
            double y = q1.X * q2.Y + q1.Y * q2.X + q1.Z * q2.W - q1.W * q2.Z;
            double z = q1.X * q2.Z - q1.Y * q2.W + q1.Z * q2.X + q1.W * q2.Y;
            double w = q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y + q1.W * q2.X;
            Quaternion q = new Quaternion(x, y, z, w);
            q.Normalize();
            return q;
        }

        public static void QuatCheck(Quaternion q, string name)
        {
            if (q.X == 0 && q.Y == 0 && q.Z == 0 && q.W == 0)
            {
                Console.WriteLine(name);
                Console.WriteLine("{0:F}, {1:F}, {2:F}, {3:F}", q.X, q.Y, q.Z, q.W);
            }
        }

        /// <summary>
        /// Converts quaternion to euler angles.
        /// </summary>
        /// <param name="q1">Quaternion to convert.</param>
        /// <returns>Vector3D as euler angles.</returns>
        public static Vector3D ToEulerAngles(this Quaternion q1)
        {
            var v = new Vector3D();

            var test = q1.X * q1.Y + q1.Z * q1.W;

            if (test > 0.4995f)
            {
                v.Y = 2f * Math.Atan2(q1.X, q1.Y);
                v.X = Math.PI / 2;
                v.Z = 0;
                return NormalizeAngles(v * Rad2Deg);
            }

            if (test < -0.4995f)
            {
                v.Y = -2f * Math.Atan2(q1.X, q1.W);
                v.X = -Math.PI / 2;
                v.Z = 0;
                return NormalizeAngles(v * Rad2Deg);
            }

            var sqx = q1.X * q1.X;
            var sqy = q1.Y * q1.Y;
            var sqz = q1.Z * q1.Z;

            v.Y = Math.Atan2(2 * q1.Y * q1.W - 2 * q1.X * q1.Z, 1 - 2 * sqy - 2 * sqz);
            v.X = Math.Asin(2 * test);
            v.Z = Math.Atan2(2 * q1.X * q1.W - 2 * q1.Y * q1.Z, 1 - 2 * sqx - 2 * sqz);

            return NormalizeAngles(v * Rad2Deg);
        }
        public static ImageSource IconToImageSource(System.Drawing.Icon icon)
        {
            return Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                new Int32Rect(0, 0, icon.Width, icon.Height),
                BitmapSizeOptions.FromEmptyOptions());
        }
    }
}