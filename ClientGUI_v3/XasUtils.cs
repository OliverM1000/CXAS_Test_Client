using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGUI_v3
{
    public static class XasUtils
    {

		#region Constants
		//----------------------------------		
		public const double H_PLANCK    = 6.62607004e-34;
        public const double C_LIGHT     = 299792458;
        public const double ME          = 9.10938356e-31;
        public const double QE          = 1.60217662e-19;
		//----------------------------------
		#endregion



		#region Public Static Methods
		//----------------------------------
		public static Int32 ConvertEnergyToAngle(double _energy, double _latticeSpacing, out double _angle)
		{
			double low_e_threshold;

			_angle = 0;
			low_e_threshold = H_PLANCK * C_LIGHT / (2.0 * QE * _latticeSpacing * 1e-10);

			if (_energy < low_e_threshold)
				return -1;

			_angle = Math.Asin(H_PLANCK * C_LIGHT / (2.0 * _latticeSpacing * 1e-10 * QE * _energy)) * 180.0 / Math.PI;

			return 1;
		}
		public static Int32 ConvertAngleToEnergy(double _angle, double _latticeSpacing, out double _energy)
		{
			_energy = 0;
			if (_angle <= 0 || _angle >= 90)
				return -1;

			_energy = H_PLANCK * C_LIGHT / (2.0 * _latticeSpacing * 1e-10 * QE * Math.Sin(_angle * Math.PI / 180.0));

			return 1;
		}
		public static Int32 ConvertEnergyToKwave(double _energy, double _edgeEnergy, out double _kWave)
		{
			_kWave = 0;
			if (_energy < _edgeEnergy)
				return -1;

			_kWave = 2.0 * Math.PI * Math.Sqrt(2.0 * ME * QE * (_energy - _edgeEnergy)) * 1e-10 / H_PLANCK;

			return 1;
		}
		public static Int32 ConvertKwaveToEnergy(double _kWave, double _edgeEnergy, out double _energy)
		{
			_energy = 0;
			if (_kWave <= 0)
				return -1;

			_energy = _kWave * _kWave * 1e20 * H_PLANCK * H_PLANCK / (8 * Math.PI * Math.PI * ME * QE) + _edgeEnergy;

			return 1;
		}
		//----------------------------------
		#endregion

	}
}
