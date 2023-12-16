using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using WPF.JsonPlaceHolder.ViewModels.Contracts;

namespace WPF.JsonPlaceHolder.ViewModels.Http;

public enum TypeREST { Get, Post, Put, Delete };

public class WPFHttpClient : IHttpClient
{
	private static volatile WPFHttpClient _instance;
	private static readonly object _syncRoot = new object();

	private readonly HttpClient _client = new();

	public static WPFHttpClient Instance
	{
		get
		{
			if (_instance == null)
			{
				lock (_syncRoot) // Verrou pour les accès multi threads
				{
					_instance ??= new WPFHttpClient();
				}
			}

			return _instance;
		}
	}

	public async Task<T> GetRequest<T>(string url)
	{
		var response = await CallHttpClient(TypeREST.Get, url);

		return await response.Content.ReadFromJsonAsync<T>();
	}

	public async Task<T> PostRequest<T, TRequest>(string url, TRequest data) where TRequest : IRequest
	{
		var response = await CallHttpClient(TypeREST.Post, url, data);

		var content = await response.Content.ReadFromJsonAsync<T>();

		return content;
	}

	public async Task<bool> PutRequest<TRequest>(string url, TRequest data) where TRequest : IRequest
	{
		var response = await CallHttpClient(TypeREST.Put, url, data);

		return response.StatusCode == HttpStatusCode.NoContent;
	}

	public async Task<bool> DeleteRequest(string url)
	{
		var response = await CallHttpClient(TypeREST.Delete, url);

		return response.StatusCode == HttpStatusCode.NoContent;
	}

	private async Task<HttpResponseMessage> CallHttpClient(TypeREST typeREST, string uri, object data = null)
	{
		try
		{
			StringContent? jsonBodyParameter = null;
			if (data != null)
				jsonBodyParameter = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

			return typeREST switch
			{
				TypeREST.Get => await _client.GetAsync(_client.BaseAddress + uri),
				TypeREST.Post => await _client.PostAsync(uri, jsonBodyParameter),
				TypeREST.Put => await _client.PutAsync(uri, jsonBodyParameter),
				TypeREST.Delete => await _client.DeleteAsync(uri),
				_ => throw new NotImplementedException("Type Rest non Valide")
			};
		}
		catch (Exception)
		{
			return new HttpResponseMessage(HttpStatusCode.BadRequest);
		}
	}
}
