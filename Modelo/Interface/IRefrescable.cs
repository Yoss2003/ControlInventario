using System.Windows.Forms;

namespace ControlInventario.Modelo.Interface
{
    public interface IMarcasRefrescable
    {
        ComboBox CbMarcasPublic { get; }
    }

    public interface ICargosRefrescable
    {
        ComboBox CbCargoPublic { get; }
    }

    public interface IAreasRefrescable
    {
        ComboBox CbAreaPublic { get; }
    }

    public interface IEstadoEmpleadosRefrescable
    {
        ComboBox CbEstadoEmpleadosPublic { get; }
    }

    public interface IEstadoArticulosRefrescable
    {
        ComboBox CbEstadoArticulosPublic { get; }
    }
}
