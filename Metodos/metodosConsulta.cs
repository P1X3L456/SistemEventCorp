using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemEventCorp.Metodos
{
    internal class metodosConsulta
    {
        public DataTable ejecutarConsulta(string consulta)
        {
            DataTable tabla = new DataTable();
            Conexion conexion = new Conexion();

            using (MySqlConnection cn = conexion.obtenerConexion())
            {
                cn.Open();

                using (MySqlCommand cmd = new MySqlCommand(consulta, cn))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(tabla);
                    }
                }
            }

            return tabla;
        }

        public DataTable ejecutarProcedimiento(string procedimiento, params MySqlParameter[] parametros)
        {
            DataTable tabla = new DataTable();
            Conexion conexion = new Conexion();

            using (MySqlConnection cn = conexion.obtenerConexion())
            {
                cn.Open();

                using (MySqlCommand cmd = new MySqlCommand(procedimiento, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parametros != null && parametros.Length > 0)
                    {
                        cmd.Parameters.AddRange(parametros);
                    }

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(tabla);
                    }
                }
            }

            return tabla;
        }

        public DataTable listarEventos()
        {
            return consultarConRespaldo(
                @"SELECT e.id_evento AS IdEvento,
                         e.codigo_evento AS Codigo,
                         e.nombre AS Evento,
                         e.fecha_inicio AS Fecha,
                         e.lugar AS Lugar,
                         COALESCE(CONCAT_WS(' ', u.nombres, u.apellidos), '') AS Responsable,
                         e.estado AS Estado,
                         e.capacidad AS Capacidad,
                         e.modalidad AS Modalidad
                  FROM eventos e
                  LEFT JOIN usuarios u ON u.id_usuario = e.id_responsable
                  ORDER BY e.fecha_inicio DESC, e.id_evento DESC",
                @"SELECT e.id_evento AS IdEvento,
                         e.codigo_evento AS Codigo,
                         e.nombre AS Evento,
                         e.fecha_inicio AS Fecha,
                         e.lugar AS Lugar,
                         COALESCE(CONCAT_WS(' ', u.nombres, u.apellidos), '') AS Responsable,
                         e.estado AS Estado,
                         e.capacidad AS Capacidad,
                         e.modalidad AS Modalidad
                  FROM evento e
                  LEFT JOIN usuario u ON u.id_usuario = e.id_responsable
                  ORDER BY e.fecha_inicio DESC, e.id_evento DESC",
                @"SELECT id_evento AS IdEvento,
                         codigo_evento AS Codigo,
                         nombre AS Evento,
                         fecha_inicio AS Fecha,
                         lugar AS Lugar,
                         '' AS Responsable,
                         estado AS Estado,
                         capacidad AS Capacidad,
                         modalidad AS Modalidad
                  FROM eventos
                  ORDER BY fecha_inicio DESC, id_evento DESC",
                @"SELECT id_evento AS IdEvento,
                         codigo_evento AS Codigo,
                         nombre AS Evento,
                         fecha_inicio AS Fecha,
                         lugar AS Lugar,
                         '' AS Responsable,
                         estado AS Estado,
                         capacidad AS Capacidad,
                         modalidad AS Modalidad
                  FROM evento
                  ORDER BY fecha_inicio DESC, id_evento DESC");
        }

        public DataTable listarEventosCatalogo()
        {
            return consultarConRespaldo(
                @"SELECT id_evento AS IdEvento,
                         CONCAT(codigo_evento, ' - ', nombre) AS Evento
                  FROM eventos
                  WHERE estado IS NULL OR estado <> 'Cancelado'
                  ORDER BY fecha_inicio DESC, id_evento DESC",
                @"SELECT id_evento AS IdEvento,
                         CONCAT(codigo_evento, ' - ', nombre) AS Evento
                  FROM evento
                  WHERE estado IS NULL OR estado <> 'Cancelado'
                  ORDER BY fecha_inicio DESC, id_evento DESC",
                @"SELECT id_evento AS IdEvento,
                         CONCAT(codigo_evento, ' - ', nombre) AS Evento
                  FROM eventos
                  ORDER BY fecha_inicio DESC, id_evento DESC",
                @"SELECT id_evento AS IdEvento,
                         CONCAT(codigo_evento, ' - ', nombre) AS Evento
                  FROM evento
                  ORDER BY fecha_inicio DESC, id_evento DESC");
        }

        public DataTable listarParticipantes()
        {
            return consultarConRespaldo(
                @"SELECT id_participante AS IdParticipante,
                         numero_documento AS Documento,
                         CONCAT_WS(' ', nombres, apellidos) AS Participante,
                         correo AS Correo,
                         telefono AS Telefono,
                         interes AS Interes,
                         estado AS Estado
                  FROM participantes
                  ORDER BY id_participante DESC",
                @"SELECT id_participante AS IdParticipante,
                         numero_documento AS Documento,
                         CONCAT_WS(' ', nombres, apellidos) AS Participante,
                         correo AS Correo,
                         telefono AS Telefono,
                         interes AS Interes,
                         estado AS Estado
                  FROM participante
                  ORDER BY id_participante DESC");
        }

        public DataTable listarParticipantesCatalogo()
        {
            return consultarConRespaldo(
                @"SELECT id_participante AS IdParticipante,
                         CONCAT(numero_documento, ' - ', CONCAT_WS(' ', nombres, apellidos)) AS Participante
                  FROM participantes
                  WHERE estado IS NULL OR estado <> 'Inactivo'
                  ORDER BY nombres, apellidos",
                @"SELECT id_participante AS IdParticipante,
                         CONCAT(numero_documento, ' - ', CONCAT_WS(' ', nombres, apellidos)) AS Participante
                  FROM participante
                  WHERE estado IS NULL OR estado <> 'Inactivo'
                  ORDER BY nombres, apellidos",
                @"SELECT id_participante AS IdParticipante,
                         CONCAT(numero_documento, ' - ', CONCAT_WS(' ', nombres, apellidos)) AS Participante
                  FROM participantes
                  ORDER BY nombres, apellidos",
                @"SELECT id_participante AS IdParticipante,
                         CONCAT(numero_documento, ' - ', CONCAT_WS(' ', nombres, apellidos)) AS Participante
                  FROM participante
                  ORDER BY nombres, apellidos");
        }

        public DataTable listarConferencias()
        {
            return consultarConRespaldo(
                @"SELECT c.id_conferencia AS IdConferencia,
                         c.id_evento AS IdEvento,
                         c.hora_inicio AS Hora,
                         c.titulo AS Conferencia,
                         c.ponente AS Ponente,
                         c.sala AS Sala,
                         c.cupo AS Cupo,
                         c.estado AS Estado,
                         e.nombre AS Evento,
                         c.fecha AS Fecha
                  FROM conferencias c
                  INNER JOIN eventos e ON e.id_evento = c.id_evento
                  ORDER BY c.fecha DESC, c.hora_inicio",
                @"SELECT c.id_conferencia AS IdConferencia,
                         c.id_evento AS IdEvento,
                         c.hora_inicio AS Hora,
                         c.titulo AS Conferencia,
                         c.ponente AS Ponente,
                         c.sala AS Sala,
                         c.cupo AS Cupo,
                         c.estado AS Estado,
                         e.nombre AS Evento,
                         c.fecha AS Fecha
                  FROM conferencia c
                  INNER JOIN evento e ON e.id_evento = c.id_evento
                  ORDER BY c.fecha DESC, c.hora_inicio",
                @"SELECT id_conferencia AS IdConferencia,
                         id_evento AS IdEvento,
                         hora_inicio AS Hora,
                         titulo AS Conferencia,
                         ponente AS Ponente,
                         sala AS Sala,
                         cupo AS Cupo,
                         estado AS Estado,
                         '' AS Evento,
                         fecha AS Fecha
                  FROM conferencias
                  ORDER BY fecha DESC, hora_inicio",
                @"SELECT id_conferencia AS IdConferencia,
                         id_evento AS IdEvento,
                         hora_inicio AS Hora,
                         titulo AS Conferencia,
                         ponente AS Ponente,
                         sala AS Sala,
                         cupo AS Cupo,
                         estado AS Estado,
                         '' AS Evento,
                         fecha AS Fecha
                  FROM conferencia
                  ORDER BY fecha DESC, hora_inicio");
        }

        public DataTable listarConferenciasCatalogo()
        {
            return consultarConRespaldo(
                @"SELECT id_conferencia AS IdConferencia,
                         CONCAT(fecha, ' - ', titulo) AS Conferencia
                  FROM conferencias
                  WHERE estado IS NULL OR estado <> 'Cancelada'
                  ORDER BY fecha DESC, hora_inicio",
                @"SELECT id_conferencia AS IdConferencia,
                         CONCAT(fecha, ' - ', titulo) AS Conferencia
                  FROM conferencia
                  WHERE estado IS NULL OR estado <> 'Cancelada'
                  ORDER BY fecha DESC, hora_inicio",
                @"SELECT id_conferencia AS IdConferencia,
                         CONCAT(fecha, ' - ', titulo) AS Conferencia
                  FROM conferencias
                  ORDER BY fecha DESC, hora_inicio",
                @"SELECT id_conferencia AS IdConferencia,
                         CONCAT(fecha, ' - ', titulo) AS Conferencia
                  FROM conferencia
                  ORDER BY fecha DESC, hora_inicio");
        }

        public DataTable listarAgendaDia()
        {
            return consultarConRespaldo(
                @"SELECT c.hora_inicio AS Hora,
                         c.titulo AS Conferencia,
                         c.ponente AS Ponente,
                         c.sala AS Sala,
                         c.cupo AS Cupo,
                         c.estado AS Estado
                  FROM conferencias c
                  WHERE c.fecha = CURDATE()
                  ORDER BY c.hora_inicio",
                @"SELECT c.hora_inicio AS Hora,
                         c.titulo AS Conferencia,
                         c.ponente AS Ponente,
                         c.sala AS Sala,
                         c.cupo AS Cupo,
                         c.estado AS Estado
                  FROM conferencia c
                  WHERE c.fecha = CURDATE()
                  ORDER BY c.hora_inicio",
                @"SELECT c.hora_inicio AS Hora,
                         c.titulo AS Conferencia,
                         c.ponente AS Ponente,
                         c.sala AS Sala,
                         c.cupo AS Cupo,
                         c.estado AS Estado
                  FROM conferencias c
                  ORDER BY c.fecha DESC, c.hora_inicio
                  LIMIT 20",
                @"SELECT c.hora_inicio AS Hora,
                         c.titulo AS Conferencia,
                         c.ponente AS Ponente,
                         c.sala AS Sala,
                         c.cupo AS Cupo,
                         c.estado AS Estado
                  FROM conferencia c
                  ORDER BY c.fecha DESC, c.hora_inicio
                  LIMIT 20");
        }

        public DataTable listarInscripciones()
        {
            return consultarConRespaldo(
                @"SELECT i.id_inscripcion AS IdInscripcion,
                         i.id_evento AS IdEvento,
                         i.id_participante AS IdParticipante,
                         i.codigo_inscripcion AS Inscripcion,
                         CONCAT_WS(' ', p.nombres, p.apellidos) AS Participante,
                         e.nombre AS Evento,
                         NULL AS Fecha,
                         i.estado AS Estado,
                         i.observacion AS Observacion
                  FROM inscripciones i
                  INNER JOIN participantes p ON p.id_participante = i.id_participante
                  INNER JOIN eventos e ON e.id_evento = i.id_evento
                  ORDER BY i.id_inscripcion DESC",
                @"SELECT i.id_inscripcion AS IdInscripcion,
                         i.id_evento AS IdEvento,
                         i.id_participante AS IdParticipante,
                         i.codigo_inscripcion AS Inscripcion,
                         CONCAT_WS(' ', p.nombres, p.apellidos) AS Participante,
                         e.nombre AS Evento,
                         NULL AS Fecha,
                         i.estado AS Estado,
                         i.observacion AS Observacion
                  FROM inscripcion i
                  INNER JOIN participante p ON p.id_participante = i.id_participante
                  INNER JOIN evento e ON e.id_evento = i.id_evento
                  ORDER BY i.id_inscripcion DESC");
        }

        public DataTable listarInscripcionesCatalogo()
        {
            return consultarConRespaldo(
                @"SELECT i.id_inscripcion AS IdInscripcion,
                         CONCAT(i.codigo_inscripcion, ' - ', CONCAT_WS(' ', p.nombres, p.apellidos), ' / ', e.nombre) AS Inscripcion
                  FROM inscripciones i
                  INNER JOIN participantes p ON p.id_participante = i.id_participante
                  INNER JOIN eventos e ON e.id_evento = i.id_evento
                  WHERE i.estado IS NULL OR i.estado <> 'Cancelada'
                  ORDER BY i.id_inscripcion DESC",
                @"SELECT i.id_inscripcion AS IdInscripcion,
                         CONCAT(i.codigo_inscripcion, ' - ', CONCAT_WS(' ', p.nombres, p.apellidos), ' / ', e.nombre) AS Inscripcion
                  FROM inscripcion i
                  INNER JOIN participante p ON p.id_participante = i.id_participante
                  INNER JOIN evento e ON e.id_evento = i.id_evento
                  WHERE i.estado IS NULL OR i.estado <> 'Cancelada'
                  ORDER BY i.id_inscripcion DESC",
                @"SELECT i.id_inscripcion AS IdInscripcion,
                         CONCAT(i.codigo_inscripcion, ' - ', CONCAT_WS(' ', p.nombres, p.apellidos), ' / ', e.nombre) AS Inscripcion
                  FROM inscripciones i
                  INNER JOIN participantes p ON p.id_participante = i.id_participante
                  INNER JOIN eventos e ON e.id_evento = i.id_evento
                  ORDER BY i.id_inscripcion DESC",
                @"SELECT i.id_inscripcion AS IdInscripcion,
                         CONCAT(i.codigo_inscripcion, ' - ', CONCAT_WS(' ', p.nombres, p.apellidos), ' / ', e.nombre) AS Inscripcion
                  FROM inscripcion i
                  INNER JOIN participante p ON p.id_participante = i.id_participante
                  INNER JOIN evento e ON e.id_evento = i.id_evento
                  ORDER BY i.id_inscripcion DESC");
        }

        public DataTable listarAsistenciaDia()
        {
            return consultarConRespaldo(
                @"SELECT a.id_asistencia AS IdAsistencia,
                         i.codigo_inscripcion AS Codigo,
                         CONCAT_WS(' ', p.nombres, p.apellidos) AS Participante,
                         e.nombre AS Evento,
                         a.hora_llegada AS Llegada,
                         a.estado AS Estado,
                         COALESCE(CONCAT_WS(' ', u.nombres, u.apellidos), '') AS AtendidoPor
                  FROM asistencias a
                  INNER JOIN inscripciones i ON i.id_inscripcion = a.id_inscripcion
                  INNER JOIN participantes p ON p.id_participante = i.id_participante
                  INNER JOIN eventos e ON e.id_evento = i.id_evento
                  LEFT JOIN usuarios u ON u.id_usuario = a.atendido_por
                  WHERE a.fecha_asistencia = CURDATE()
                  ORDER BY a.hora_llegada DESC",
                @"SELECT a.id_asistencia AS IdAsistencia,
                         i.codigo_inscripcion AS Codigo,
                         CONCAT_WS(' ', p.nombres, p.apellidos) AS Participante,
                         e.nombre AS Evento,
                         a.hora_llegada AS Llegada,
                         a.estado AS Estado,
                         COALESCE(CONCAT_WS(' ', u.nombres, u.apellidos), '') AS AtendidoPor
                  FROM asistencia a
                  INNER JOIN inscripcion i ON i.id_inscripcion = a.id_inscripcion
                  INNER JOIN participante p ON p.id_participante = i.id_participante
                  INNER JOIN evento e ON e.id_evento = i.id_evento
                  LEFT JOIN usuario u ON u.id_usuario = a.atendido_por
                  WHERE a.fecha_asistencia = CURDATE()
                  ORDER BY a.hora_llegada DESC");
        }

        public DataTable listarCertificados()
        {
            return consultarConRespaldo(
                @"SELECT c.id_certificado AS IdCertificado,
                         c.codigo_certificado AS Certificado,
                         CONCAT_WS(' ', p.nombres, p.apellidos) AS Participante,
                         e.nombre AS Evento,
                         c.horas_reconocidas AS Horas,
                         c.estado AS Estado,
                         c.fecha_emision AS Entrega,
                         c.ruta_archivo AS RutaArchivo,
                         c.observacion AS Observacion
                  FROM certificados c
                  INNER JOIN inscripciones i ON i.id_inscripcion = c.id_inscripcion
                  INNER JOIN participantes p ON p.id_participante = i.id_participante
                  INNER JOIN eventos e ON e.id_evento = i.id_evento
                  ORDER BY c.id_certificado DESC",
                @"SELECT c.id_certificado AS IdCertificado,
                         c.codigo_certificado AS Certificado,
                         CONCAT_WS(' ', p.nombres, p.apellidos) AS Participante,
                         e.nombre AS Evento,
                         c.horas_reconocidas AS Horas,
                         c.estado AS Estado,
                         c.fecha_emision AS Entrega,
                         c.ruta_archivo AS RutaArchivo,
                         c.observacion AS Observacion
                  FROM certificado c
                  INNER JOIN inscripcion i ON i.id_inscripcion = c.id_inscripcion
                  INNER JOIN participante p ON p.id_participante = i.id_participante
                  INNER JOIN evento e ON e.id_evento = i.id_evento
                  ORDER BY c.id_certificado DESC");
        }

        public DataTable listarUsuarios()
        {
            return consultarConRespaldo(
                @"SELECT u.id_usuario AS IdUsuario,
                         u.id_rol AS IdRol,
                         u.nombre_usuario AS Usuario,
                         r.nombre AS Rol,
                         CONCAT_WS(' ', u.nombres, u.apellidos) AS Responsabilidad,
                         u.estado AS Estado,
                         NULL AS UltimoAcceso,
                         '' AS Observacion
                  FROM usuarios u
                  INNER JOIN roles r ON r.id_rol = u.id_rol
                  ORDER BY u.id_usuario DESC",
                @"SELECT u.id_usuario AS IdUsuario,
                         u.id_rol AS IdRol,
                         u.nombre_usuario AS Usuario,
                         r.nombre AS Rol,
                         CONCAT_WS(' ', u.nombres, u.apellidos) AS Responsabilidad,
                         u.estado AS Estado,
                         NULL AS UltimoAcceso,
                         '' AS Observacion
                  FROM usuario u
                  INNER JOIN rol r ON r.id_rol = u.id_rol
                  ORDER BY u.id_usuario DESC");
        }

        public DataTable listarRoles()
        {
            return consultarConRespaldo(
                @"SELECT id_rol AS IdRol, nombre AS Rol, descripcion AS Descripcion
                  FROM roles
                  ORDER BY nombre",
                @"SELECT id_rol AS IdRol, nombre AS Rol, descripcion AS Descripcion
                  FROM rol
                  ORDER BY nombre");
        }

        public int contarRegistros(string tabla, string tablaAlterna)
        {
            try
            {
                DataTable datos = consultarConRespaldo(
                    "SELECT COUNT(*) AS Total FROM " + tabla,
                    "SELECT COUNT(*) AS Total FROM " + tablaAlterna);

                return Convert.ToInt32(datos.Rows[0]["Total"]);
            }
            catch
            {
                return 0;
            }
        }

        public int contarCertificadosPendientes()
        {
            try
            {
                DataTable datos = consultarConRespaldo(
                    "SELECT COUNT(*) AS Total FROM certificados WHERE estado = 'Pendiente'",
                    "SELECT COUNT(*) AS Total FROM certificado WHERE estado = 'Pendiente'");

                return Convert.ToInt32(datos.Rows[0]["Total"]);
            }
            catch
            {
                return 0;
            }
        }

        private DataTable consultarConRespaldo(params string[] consultas)
        {
            Exception ultimoError = null;

            foreach (string consulta in consultas)
            {
                try
                {
                    return ejecutarConsulta(consulta);
                }
                catch (Exception ex)
                {
                    ultimoError = ex;
                }
            }

            throw new InvalidOperationException("No se pudo obtener la informacion solicitada.", ultimoError);
        }
    }
}
